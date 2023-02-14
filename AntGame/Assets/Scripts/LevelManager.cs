using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public bool WaitWinCon; // if the win condition is to run out the clock, set to true

    // UI elements
    public Slider slider;


    // The amount of time the user has to beat a level
    public float levelTime;
    [HideInInspector]
    public float modifiedLT;

    // References to other scripts
    private GameManager gm;
    //private AudioManager am;

    const float LOGRATE = 1.4f;
    const float LVLSTANDARD = 20f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the necessary variables
        gm = FindObjectOfType<GameManager>();
        // am = FindObjectOfType<AudioManager>();

        // set the modified level time
        ModifyLevelTime(gm.GetLevelsBeaten());
    }

    // Update is called once per frame
    void Update()
    {
        modifiedLT -= Time.deltaTime; // ensures that timing is consistent
        if(slider)
            slider.value = modifiedLT;

        if (modifiedLT <= 0)
        {
            CompleteLevel(WaitWinCon);
        }
    }

    // TODO put pause menu in here maybe
    void GetInput()
    {
        
    }

    /**
     * Called when the level is complete
     * win should be true if they successfully completed the level, false otherwise
     */
    public void CompleteLevel(bool win)
    {
        gm.EnterScoreScreen(win);
    }

    /**
     * Gives the user less time depending on how many levels they've beaten
     * 
     * TODO make this actually incorporate levelsBeaten
     */
    private void ModifyLevelTime(int levelsBeaten)
    {
        modifiedLT = levelTime * ((LVLSTANDARD -
            (Mathf.Log10(levelsBeaten + 1)
            / Mathf.Log10(LOGRATE)))
            / LVLSTANDARD);

        // set the slider to match this
        if (slider)
        {
            slider.maxValue = modifiedLT;
            slider.value = modifiedLT;
        }
        else
        {
            Debug.Log("Time Slider not set!");
        }

        Debug.Log("Modified Time: " + modifiedLT);
    }
}
