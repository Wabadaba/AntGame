using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GymGameManager : MonoBehaviour
{
    private int fiveL = 0;
    private int fiveLtwo = 0;
    private int fiveR = 0;
    private int fiveRtwo = 0;
    private int tenL = 0;
    private int tenLtwo = 0;
    private int tenR = 0;
    private int tenRtwo = 0;
    private int twentyFiveL = 0;
    private int twentyFiveR = 0;
    private int fortyFiveL = 0;
    private int fortyFiveR = 0;
    
    private int[] randomWeights = new int[] { 90, 110, 120, 140, 130, 100, 170, 30, 50, 10 };
    private int randomWeight;

    const float MAXALPHA = 255;

    private bool fadeIn;

    public TMP_Text weightText;

    GameObject clickedOnObject;

    // Start is called before the first frame update
    void Start()
    {
        weightText.alpha = 0;
        fadeIn = true;

        int randomWeightIndex = Random.Range(0, randomWeights.Length);
        randomWeight = randomWeights[randomWeightIndex];

        weightText.text = "Weight: " + randomWeight.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            weightText.alpha += Time.deltaTime;
            if (weightText.alpha >= MAXALPHA)
                fadeIn = false;
        }
        if (Input.GetMouseButtonDown(0))
        {   
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (hit != false)
            {
                clickedOnObject = hit.transform.gameObject;

                MouseClick();
            }
        }
    }

    private void MouseClick()
    {
        if (clickedOnObject.name == "5L")
        {
            fiveL = 5;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "5L2")
        {
            fiveLtwo = 5;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "5R")
        {
            fiveR = 5;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "5R2")
        {
            fiveRtwo = 5;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "10L")
        {
            tenL = 10;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "10L2")
        {
            tenLtwo = 10;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "10R")
        {
            tenR = 10;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "10R2")
        {
            tenRtwo = 10;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "25L")
        {
            twentyFiveL = 25;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "25R")
        {
            twentyFiveR = 25;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "45L")
        {
            fortyFiveL = 45;
            clickedOnObject.SetActive(false);
        }
        else if (clickedOnObject.name == "45R")
        {
            fortyFiveR = 45;
            clickedOnObject.SetActive(false);
        }

        addWeights();
    }

    private void addWeights()
    {
        int chicken = fiveL + fiveLtwo + tenL + tenLtwo + twentyFiveL + fortyFiveL;
        int cow = fiveR + fiveRtwo + tenR + tenRtwo + twentyFiveR + fortyFiveR;
        Debug.Log(randomWeight);
        if ((fiveL + fiveLtwo + tenL + tenLtwo + twentyFiveL + fortyFiveL) == (fiveR + fiveRtwo + tenR + tenRtwo + twentyFiveR + fortyFiveR))
        {
            if ((fiveL + fiveLtwo + tenL + tenLtwo + twentyFiveL + fortyFiveL) == (randomWeight/2))
            {
                WinLevel();
            }
        }
        if ((fiveL + fiveLtwo + tenL + tenLtwo + twentyFiveL + fortyFiveL) > (randomWeight/2))
        {
            LoseLevel();
        }
        if ((fiveR + fiveRtwo + tenR + tenRtwo + twentyFiveR + fortyFiveR) > (randomWeight / 2))
        {
            LoseLevel();
        }
    }

    private void WinLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(true);
    }

    private void LoseLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(false);
    }

    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(1);
        fadeIn = true;
    }
}
