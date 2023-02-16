using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MookMover : MonoBehaviour
{

    public bool isRunning;
    private Vector3 v3moveSpeed;
    public Vector2 moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        v3moveSpeed = new Vector3(moveSpeed.x/100, moveSpeed.y/100, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + v3moveSpeed;
    }

    private void OnMouseDown()
    {
        if (isRunning)
        {
            FindObjectOfType<LevelManager>().CompleteLevel(true);
        }
        else
        {
            FindObjectOfType<LevelManager>().CompleteLevel(false);
        }
    }
}
