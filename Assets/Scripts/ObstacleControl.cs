using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
  public float PERFECT_THRESHOLD;
  public float MISTIME_THRESHOLD;
  // Start is called before the first frame update
  protected virtual void Start() {
    state = States.UNINTERACTABLE;
    // beat gives us the starting x position, offset by camSize/2
    camSize = Camera.main.orthographicSize * Camera.main.aspect;
    BoxCollider2D collider = GetComponent<BoxCollider2D>();
    transform.position = new Vector3(beat - 4, transform.position.y, transform.position.z);
  }

  // Update is called once per frame
  protected virtual void Update() {
    switch (state) {
      case States.DESTROYABLE:
        if (Input.GetKey("space")) {
          gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
          calcScore(DebugInfo.getBeatsElapsed());
          state = States.DYING;
        }
        // Despawn if you go off screen
        if (DebugInfo.getBeatsElapsed() > beat + 2) {
          state = States.DESPAWNING;
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

  protected virtual void calcScore(float beatPressed) {
    Debug.Log("Pressed on " + beatPressed);
    float beatDiff = (beat - beatPressed);
    Debug.Log("Beat diff " + beatDiff);
    if (Math.Abs(beatDiff) < PERFECT_THRESHOLD) {
      Debug.Log("Perfect");
    }
    else if (beatDiff > PERFECT_THRESHOLD && beatDiff < MISTIME_THRESHOLD) {
      Debug.Log("Early");
    }
    else if (beatDiff < -PERFECT_THRESHOLD && beatDiff > -MISTIME_THRESHOLD) {
      Debug.Log("Late");
    }
    else {
      Debug.Log("Miss");
    }
  }
}
