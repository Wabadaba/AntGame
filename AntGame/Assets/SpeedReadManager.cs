using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReadManager : MonoBehaviour
{
    const float LOWERBOUND = -27.3f;
    const float UPPERBOUND = 27.3f;

    const float DRAGCONSTANT = 0.97f;
    float mousePosY;
    float lastMousePosY;

    float mousePosDiff;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.GetMouseButton(0))
        {
            mousePosDiff *= DRAGCONSTANT;
        }
        
        transform.position += new Vector3(0, mousePosDiff, 0);


        if (transform.position.y < LOWERBOUND)
            transform.position = new Vector3(0, LOWERBOUND, 0);

        else if (transform.position.y > UPPERBOUND)
            WinLevel();
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        // track the previous frame
        lastMousePosY = Camera.main.ScreenToWorldPoint(mousePos).y;
        mousePosY = lastMousePosY;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        // track the previous frame
        lastMousePosY = mousePosY;
        mousePosY = Camera.main.ScreenToWorldPoint(mousePos).y;
        

        mousePosDiff = (mousePosY - lastMousePosY) * 4;
    }

    private void WinLevel()
    {
        FindObjectOfType<LevelManager>().CompleteLevel(true);
    }
}
