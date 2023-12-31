using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DebugInfo : MonoBehaviour {
  public Text debugText;
  private static float beatsElapsed;
  public static float scaleFactor = 6f;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    beatsElapsed = Camera.main.transform.position.x / scaleFactor;
    if (Input.GetKey(KeyCode.Tab)) {
      debugText.text = "Beat: " + (Mathf.Round(beatsElapsed * 100f) / 100);
    }
    else {
      debugText.text = "Beat: " + (Mathf.Round(beatsElapsed * 100f) / 100);
      // During the actual build:
      //debugText.text = null;
    }
  }

  public static float getBeatsElapsed() {
    return beatsElapsed;
  }
}
