using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreenManager : MonoBehaviour
{

    const float MAXALPHA = 255;
    const float INPUTWAITTIME = 2f;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text continueText;

    private int score;
    private int lives;

    GameManager gm;

    private bool canSkip;
    private bool fadeIn;


    // Start is called before the first frame update
    void Start()
    {
        continueText.alpha = 0;

        gm = FindObjectOfType<GameManager>();
        score = gm.GetScore();
        lives = gm.GetLives();

        UpdateUI(score, lives);

        canSkip = false;
        fadeIn = false;
        StartCoroutine(WaitForNextLevel());
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
        if (scoreText && livesText)
        {
            scoreText.text = "Score: " + score.ToString();
            livesText.text = "Lives: " + lives.ToString();
        }
        else
        {
            Debug.Log("ScoreText/LivesText not set!");
        }
    }

    private void ShowContinueText()
    {
        if (continueText)
        {

        }
    }

    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(INPUTWAITTIME);
        ShowContinueText();
        canSkip = true;
        fadeIn = true;
    }
}
