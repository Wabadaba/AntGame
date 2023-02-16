using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScreenManager : MonoBehaviour
{
    private bool fromWin;

    public Sprite caption;
    public Sprite sadant;

    public GameObject ant1;
    public GameObject ant2;
    public GameObject ant3;

    const float MAXALPHA = 255;
    const float INPUTWAITTIME = 2f;
    const float EXPLOSIONWAITTIME = 0.5f;

    public TMP_Text scoreText;
    public TMP_Text continueText;

    private int score;
    private int lives;

    GameManager gm;

    private bool canSkip;
    private bool fadeIn;

    public ParticleSystem explosionPrefab;
    private ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        ant1.GetComponent<Image>().sprite = caption;
        ant1.GetComponent<Image>().sprite = caption;
        ant1.GetComponent<Image>().sprite = caption;

        continueText.alpha = 0;

        gm = FindObjectOfType<GameManager>();
        
        score = gm.GetScore();
        lives = gm.GetLives();
        fromWin = gm.GetLastWin();

        UpdateUI(score, lives);

        canSkip = false;
        fadeIn = false;
        StartCoroutine(WaitForNextLevel());

        // if a loss, begin the loss animation
        if (!fromWin)
            StartCoroutine(WaitForExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            continueText.alpha += Time.deltaTime;
            if (continueText.alpha >= MAXALPHA)
                fadeIn = false;
        }

        if(canSkip && Input.GetMouseButtonDown(0))
        {
            gm.SelectNextLevel();
        }
    }

    /**
    * Update the UI
    */
    public void UpdateUI(int score, int lives)
    {
        if (scoreText)
        {
            scoreText.text = "Score: " + score.ToString();
        }

        // set up for ant explosion
        if (!fromWin) lives += 1;

        if (lives >= 3)
        {
            ant3.GetComponent<Image>().sprite = caption;
        }
        else
        {
            ant3.GetComponent<Image>().sprite = sadant;
            ant3.GetComponent<Animator>().enabled = false;
        }

        if (lives >= 2)
        {
            ant2.GetComponent<Image>().sprite = caption;
        }
        else
        {
            ant2.GetComponent<Image>().sprite = sadant;
            ant2.GetComponent<Animator>().enabled = false;
        }

        if (lives >= 1)
        {
            ant1.GetComponent<Image>().sprite = caption;
        }
        else
        {
            ant1.GetComponent<Image>().sprite = sadant;
            ant1.GetComponent<Animator>().enabled = false;
        }
    }
    private void Explode()
    {
        Vector3 antPos = new Vector3(0,0,0);
        if (lives == 2)
            antPos = ant3.transform.position;
        if (lives == 1)
            antPos = ant2.transform.position;
        explosionParticles = ParticleSystem.Instantiate(explosionPrefab, antPos, Quaternion.identity);
        explosionParticles.Play();

        if(lives == 2)
        {
            ant3.GetComponent<Image>().sprite = sadant;
            ant3.GetComponent<Animator>().enabled = false;
        }

        else if (lives == 1)
        {
            ant2.GetComponent<Image>().sprite = sadant;
            ant2.GetComponent<Animator>().enabled = false;
        }
    }
        IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(INPUTWAITTIME);
        canSkip = true;
        fadeIn = true;
    }

    IEnumerator WaitForExplosion()
    {
        yield return new WaitForSeconds(EXPLOSIONWAITTIME);
        Explode();
    }
}
