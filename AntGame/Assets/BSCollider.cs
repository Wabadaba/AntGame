using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSCollider : MonoBehaviour
{
    public bool emptyIns;

    public bool insCollideBool = false;
    public bool glucCollideBool = false;

    GameObject insCollider;
    GameObject glucCollider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (emptyIns)
        {
            insCollideBool = true;
            insCollider = collider.gameObject;
        }
        else
        {
            glucCollideBool = true;
            glucCollider = collider.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (emptyIns)
            insCollideBool = false;
        else
            glucCollideBool = false;
    }

    // true if insulin, false if glucose
    public void ClickedButton()
    {

        if (emptyIns)
        {
            if (insCollideBool)
            {
                Destroy(insCollider);
            }
            else
            {
                LoseLevel();
            }
        }
        else
        {
            if (glucCollideBool)
            {
                Destroy(glucCollider);
            }
            else
            {
                LoseLevel();
            }
        }
    }

    private void LoseLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(false);
    }
}
