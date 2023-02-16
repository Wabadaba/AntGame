using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSCollider : MonoBehaviour
{
    public bool insCollideBool = false;
    public bool glucCollideBool = false;

    GameObject clickedOnObject;
    GameObject insCollider;
    GameObject glucCollider;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

            if (hit != false)
            {
                clickedOnObject = hit.transform.gameObject;

                if (insCollideBool == false && glucCollideBool == false)
                {
                    if (clickedOnObject.name == "ins(Clone)" || clickedOnObject.name == "gluc(Clone)")
                    {
                        Debug.Log("LOST1"); // clicked a clone that wasnt in the right place
                    }
                }

                else if (insCollideBool)
                {
                    if (clickedOnObject.name == "ins(Clone)")
                    {
                        insCollider.SetActive(false);
                    }
                }

                else if (glucCollideBool)
                {
                    if (clickedOnObject.name == "gluc(Clone)")
                    {
                        glucCollider.SetActive(false);
                    }
                }

            }
            else
            {
                Debug.Log("LOST3"); // missed the clone or clicked nothing
            }
        }
    }

    /*private void OnMouseDown()
    {
        if (insCollideBool)
        {
            insCollider.SetActive(false);
        }
        else if (glucCollideBool)
        {
            glucCollider.SetActive(false);
        }
        else
        {
            Debug.Log("LOST2"); // clicked the empty one with no clone
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "ins(Clone)")
        {
            insCollideBool = true;
            insCollider = collider.gameObject;
        }
        else if (collider.gameObject.name == "gluc(Clone)")
        {
            glucCollideBool = true;
            glucCollider = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "ins(Clone)")
        {
            insCollideBool = false;
        }
        else if (collider.gameObject.name == "gluc(Clone)")
        {
            glucCollideBool = false;
        }
    }
}
