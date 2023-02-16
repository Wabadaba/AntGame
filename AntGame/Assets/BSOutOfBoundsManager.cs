using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSOutOfBoundsManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoseLevel();
    }

    private void LoseLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(false);
    }
}
