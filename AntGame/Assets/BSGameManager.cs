using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSGameManager : MonoBehaviour
{
    GameObject clickedOnObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (hit != false) 
            {
                clickedOnObject = hit.transform.gameObject;
                if (clickedOnObject.name == "gluc(Clone)" || clickedOnObject.name == "ins(Clone)")
                {
                    MouseClick();
                }
            }
        }
    }

    private void MouseClick()
    {
        clickedOnObject.SetActive(false);
    }
}
