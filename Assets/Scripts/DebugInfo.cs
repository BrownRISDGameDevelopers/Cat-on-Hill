using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DebugInfo : MonoBehaviour
{
    private GameObject player;
    public Text debugText;
    private float beatsElapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     beatsElapsed = Camera.main.transform.position.x;
     if (Input.GetKey(KeyCode.Tab))
     {
        debugText.text = "Beats Elapsed: " + (Mathf.Round(beatsElapsed *100f)/100);
     }
     else 
     {
        debugText.text = null;
     }
    }
}
