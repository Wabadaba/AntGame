using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupDragger : MonoBehaviour
{

    float mousePosX;

    public float GetCupPosition()
    {
        return mousePosX;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePosX = Camera.main.ScreenToWorldPoint(mousePos).x;

        transform.position = new Vector3(mousePosX, transform.position.y, 0);
    }
}
