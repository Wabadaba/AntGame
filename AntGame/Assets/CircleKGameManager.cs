using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleKGameManager : MonoBehaviour
{
    // very hardcodey, but running out of time
    float[] SODAPOSITIONS = new float[] { -7.75f, -5.85f, -3.95f, -2.05f, 
        2.05f, 3.95f, 5.85f, 7.75f };

    const float CUPRADIUS = 0.7f;

    public Sprite[] sodaList;
    public GameObject[] sodaObjects;

    public Sprite dietCokeSprite;
    private int dcIndex;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleSprites(sodaList);
        dcIndex = FindDietCokeIndex();
        Debug.Log("dc: " + dcIndex);

        // randomize the sprites to be soda
        for(int i = 0; i < sodaList.Length; i++)
        {
            sodaObjects[i].GetComponent<SpriteRenderer>().sprite = sodaList[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleSprites(Sprite[] sodas)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < sodas.Length; t++)
        {
            Sprite tmp = sodas[t];
            int r = Random.Range(t, sodas.Length);
            sodas[t] = sodas[r];
            sodas[r] = tmp;
        }
    }

    int FindDietCokeIndex()
    {
        for(int i = 0; i < sodaList.Length; i++)
        {
            if(sodaList[i] == dietCokeSprite)
            {
                return i;
            }
        }
        Debug.Log("ERROR: Could not find the Diet Coke image");
        return -1;
    }

    public void ButtonClicked(int sodaID)
    {
        float cupX = FindObjectOfType<CupDragger>().GetCupPosition();

        float cupLeftBound = SODAPOSITIONS[dcIndex] - CUPRADIUS;
        float cupRightBound = SODAPOSITIONS[dcIndex] + CUPRADIUS;

        if(cupX > cupLeftBound && cupX < cupRightBound)
        {
            WinLevel();
        }

        else
        {
            LoseLevel();
        }
    }

    private void LoseLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(false);
    }

    private void WinLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(true);
    }

}
