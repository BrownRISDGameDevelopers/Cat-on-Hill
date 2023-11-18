using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour {
  public GameObject[] panels = new GameObject[2];

  public Camera main_camera;

  private SpriteRenderer panel_renderer;

  private float width;
  public float relSpeedOffset;

  // Start is called before the first frame update
  void Start() {
    panel_renderer = panels[0].GetComponent<SpriteRenderer>();
    width = panel_renderer.bounds.size.x;
  }

  // Update is called once per frame
  void Update() {
    transform.position += new Vector3(relSpeedOffset * Time.deltaTime, 0f, 0f);
    if (panels[0].transform.position.x <= (main_camera.transform.position.x - (main_camera.orthographicSize * main_camera.aspect) - width / 2)) {
      panels[0].transform.position = new Vector3(panels[1].transform.position.x + (width) - 1, panels[1].transform.position.y, panels[1].transform.position.z);
      GameObject first_panel = panels[0];
      panels[0] = panels[1];
      panels[1] = first_panel;
    }
  }
}
