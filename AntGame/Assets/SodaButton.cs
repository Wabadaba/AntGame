using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaButton : MonoBehaviour
{
    // Start is called before the first frame update

    public int sodaID;

    private void OnMouseDown()
    {
        FindObjectOfType<CircleKGameManager>().ButtonClicked(sodaID);
    }
}
