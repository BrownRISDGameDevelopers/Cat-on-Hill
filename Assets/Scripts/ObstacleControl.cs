using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {
  protected enum States {
    UNINTERACTABLE,
    DESTROYABLE,
    DYING,
    DESPAWNING
  }
  protected States state;
  public float despawnTimer;
  public float timerToChangeSprite;
  public Sprite deadSprite;
  public float beat;
  private float camSize;
  // Start is called before the first frame update
  protected virtual void Start() {
    state = States.UNINTERACTABLE;
    // beat gives us the starting x position, offset by camSize/2
    camSize = Camera.main.orthographicSize * Camera.main.aspect;
    transform.position = new Vector3(beat - camSize / 2, transform.position.y, transform.position.z);
  }

  // Update is called once per frame
  protected virtual void Update() {
    switch (state) {
      case States.DESTROYABLE:
        if (Input.GetKey("space")) {
          gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
          state = States.DYING;
        }
        break;
      case States.DYING:
        timerToChangeSprite -= Time.deltaTime;
        if (timerToChangeSprite <= 0) {
          state = States.DESPAWNING;
        }
        break;
      case States.DESPAWNING:
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0) {
          Destroy(gameObject);
        }
        break;
    }
  }
  protected virtual void OnTriggerEnter2D(Collider2D other) {
    string otherTag = other.tag;
    switch (otherTag) {
      case "Player":
        state = States.DESTROYABLE;
        break;
    }
  }
}
