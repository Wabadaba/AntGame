using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO randomize images, make it so it's not always the last one
public class TinderGameManager : MonoBehaviour
{
    const int WILLINDEX = 3;

    Vector3 mousePosDown;
    Vector3 mousePosUp;

    public Sprite[] matches;
    private int matchIndex;

    // Start is called before the first frame update
    void Start()
    {
        // set the initial match when the game starts
        SetMatch(0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePosDown = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePosUp = Camera.main.ScreenToWorldPoint(mousePos);

        SwipeCheck();
    }

    private void SwipeCheck()
    {
        //swipe right
        if(mousePosDown.x < mousePosUp.x - 2)
        {
            if (CheckWill())
            {
                // win if swipe right on will
                WinLevel();
            }
            else
            {
                // lose if swipe right on not will
                LoseLevel();
            }
        }

        //swipe left
        else if (mousePosDown.x > mousePosUp.x + 2)
        {
            if (!CheckWill())
            {
                matchIndex += 1;
                SetMatch(matchIndex);
            }
            else
            {
                // lose if you swipe left on will
                LoseLevel();
            }
        }
    }

    private void SetMatch(int index)
    {
        GetComponent<SpriteRenderer>().sprite = matches[index];
    }
    private bool CheckWill()
    {
        if (matchIndex == WILLINDEX)
            return true;
        return false;
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
