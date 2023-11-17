using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
  public int bpm;
  private float bps;
  // Start is called before the first frame update
  void Start() {
    bps = bpm / 60f;
  }

  // Update is called once per frame
  void Update() {
    transform.position += new Vector3(bps * DebugInfo.scaleFactor * Time.deltaTime, 0f, 0f);
  }
}
