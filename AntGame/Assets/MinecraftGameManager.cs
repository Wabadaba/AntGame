using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinecraftGameManager : MonoBehaviour
{

    public int clicksNeeded;
    private int clickNumber;
    private SpriteRenderer sr;
    [SerializeField]
    ParticleSystem particles;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        slider.maxValue = clicksNeeded;
        slider.value = clicksNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider)
        {
            slider.value = (clicksNeeded - clickNumber);
        }
    }

    private void OnMouseDown()
    {
        clickNumber += 1;
        sr.color = new Color(1, 0.74f, 0.74f);
        GetComponent<Animator>().SetTrigger("Clicked");
        particles.Emit(10);

        StopCoroutine("WaitForNextLevel");
        StartCoroutine("WaitForNextLevel");


        if (clickNumber == clicksNeeded)
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(true);
    }
    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(255, 255, 255);
    }
}
