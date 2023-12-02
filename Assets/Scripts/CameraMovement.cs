using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
  public int bpm;
  private float bps;
  private Boolean shouldMove = false;
  // Start is called before the first frame update
  void Start() {
    bps = bpm / 60f;
    StartCoroutine(WaitForAudio());
  }

  // Update is called once per frame
  void Update() {
    if (shouldMove) {
      transform.position += new Vector3(bps * DebugInfo.scaleFactor * Time.deltaTime, 0f, 0f);
    }
  }

  IEnumerator WaitForAudio() {
    yield return new WaitForSeconds(0.5f);
    shouldMove = true;
  }
}
