using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GetComponentInParent<BSCollider>().ClickedButton();
    }
}
