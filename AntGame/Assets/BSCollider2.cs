using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSCollider2 : MonoBehaviour
{
    public bool glucCollideBool = false;

    GameObject clickedOnObject;
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

                if (glucCollideBool)
                {
                    if (clickedOnObject.name == "gluc(Clone)")
                    {
                        glucCollider.SetActive(false);
                        glucCollideBool = true;
                    }
                }

                else
                {
                    Debug.Log("LOST2"); // clicked the empty one with no clone
                }

            }
            else
            {
                Debug.Log("LOST3"); // missed the clone or clicked nothing
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "gluc(Clone)")
        {
            glucCollideBool = true;
            glucCollider = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "gluc(Clone)")
        {
            glucCollideBool = false;
        }
    }
}
