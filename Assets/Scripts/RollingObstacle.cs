using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BouncingObstacle : ObstacleControl {
  private Rigidbody2D rb;
  public float yVel;
  public float xVel;
  public float spinSpeed;
  public float maxHeight;
  // Start is called before the first frame update
  protected override void Start() {
    base.Start();
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  protected override void Update() {
    base.Update();
    transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    transform.position += new Vector3(xVel * Time.deltaTime, -yVel * Time.deltaTime, 0);
    if (transform.position.y > maxHeight) {
      yVel *= -1;
    }
  }
  protected override void OnTriggerEnter2D(Collider2D other) {
    string otherTag = other.tag;
    Debug.Log("Collided " + otherTag);
    switch (otherTag) {
      case "Floor":
        yVel *= -1;
        break;
      case "Player":
        state = States.DESTROYABLE;
        break;
    }
  }
}
