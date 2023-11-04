using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DebugInfo : MonoBehaviour {
  private GameObject player;
  private TextMeshPro debugText;
  private static float beatsElapsed;
  // Start is called before the first frame update
  void Start() {
    debugText = gameObject.GetComponent<TextMeshPro>();
  }

  // Update is called once per frame
  void Update() {
    beatsElapsed = Camera.main.transform.position.x;
    if (Input.GetKey(KeyCode.Tab)) {
      Debug.Log("Tab held");
      debugText.text = "Beats Elapsed: " + (Mathf.Round(beatsElapsed * 100f) / 100);
    }
    else {
      debugText.text = null;
    }
  }

  public static float getBeatsElapsed() {
    return beatsElapsed;
  }
}
