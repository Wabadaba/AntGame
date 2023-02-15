using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* * * * * * * * * * * * * * * * * * *
 * Handles everything to do with actually running the game
 * Tracks lives, changes the scene, tracks score, etc
 * * * * * * * * * * * * * * * * * * */

/* TODO
 * - play the music of the game
 * - make it so you can't get the same level twice in a row
 */
public class GameManager : MonoBehaviour
{
    private int score;           // the score of the player
    private int levelsBeaten;    // # of lvls the player has beat
    private int remainingLives;  // # of lives the player has left

    [SerializeField]
    private string[] levelScenes; // the list of scenes that are actually levels
    [SerializeField]
    private string scoreScene; // the scene that displays the player's score

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("mainsoundtrack");
    }

    /**
     * Does everything necessary to start a game
     * sets variables, puts the player into a scene
     */
    public void StartGame()
    {
        remainingLives = 3;
        score = 0;
        levelsBeaten = 0;


        //FindObjectOfType<AudioManager>().Play("main_soundtrack");
        SelectNextLevel();
    }

    /**
     * Increments the score of the player
     * if trick is true, gives them extra score
     */
    public void IncrementScore(int score)
    {
        this.score += score;
    }

    /**
     * Gets the score of the player
     */
    public int GetScore()
    {
        return score;
    }

    /**
     * Adds one to level beaten if a level is beaten
     */
    public void IncrementLevelsBeaten() { levelsBeaten += 1; }

    /**
     * Gets levels beaten
     */
    public int GetLevelsBeaten() { return levelsBeaten; }

    /**
     * Loses a life if the player dies
     */
    public void LoseLife()
    {
        remainingLives -= 1;
        if (remainingLives <= 0)
            GameOver();
    }

    public int GetLives() { return remainingLives; }

    public void SelectNextLevel()
    {
        int nextScene = Random.Range(0, levelScenes.Length);
        SceneManager.LoadScene(levelScenes[nextScene]);
    }

    public void EnterScoreScreen(bool win)
    {
        if (win)
        {
            IncrementScore(1);
            IncrementLevelsBeaten();
        }
        else
        {
            LoseLife();
        }

        if(remainingLives > 0)
        {
            SceneManager.LoadScene(scoreScene);
        }

    }

    /**
     * Handles what happens when the player loses the game
     */
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
