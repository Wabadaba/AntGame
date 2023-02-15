using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + FindObjectOfType<GameManager>().GetScore().ToString();
    }

    // Update is called once per frame
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
