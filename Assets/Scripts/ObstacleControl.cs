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
  public float dyingAnimTimer;
  public Sprite deadSprite;
  public float beat;
  public float PERFECT_THRESHOLD;
  public float MISTIME_THRESHOLD;
  private float deathxVel;
  private float deathyVel;
  private float deathSpinSpeed;
  private float deathMaxHeight;
  public ParticleSystem deathParticleSystem;
  public ScoreManager scoreManager;
  private BoxCollider2D collider;
  public float beatOffset = 1.3f;
  public float positionScale = 0f;

  // Start is called before the first frame update
  protected virtual void Start() {
    state = States.UNINTERACTABLE;
    collider = GetComponent<BoxCollider2D>();
    transform.position = new Vector3((beat * DebugInfo.scaleFactor) - 1.5f + positionScale, transform.position.y, transform.position.z);
    beat += beatOffset;
    deathxVel = -12.5f;
    deathyVel = 25f;
    deathSpinSpeed = 2250f;
    deathMaxHeight = 10f;
  }

  // Update is called once per frame
  protected virtual void Update() {
    switch (state) {
      case States.DESTROYABLE:
        if (Input.GetKeyDown("space")) {
          gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
          calcScore(DebugInfo.getBeatsElapsed());
          // var em = deathParticleSystem.emission;
          // em.enabled = true;
          // deathParticleSystem.Play();
          state = States.DYING;
        }
        // Despawn if you go off screen
        // if (DebugInfo.getBeatsElapsed() > beat + 2) {
        //   state = States.DESPAWNING;
        // }
        break;
      case States.DYING:
        collider.enabled = false;
        dyingAnimTimer -= Time.deltaTime;
        transform.Rotate(0, 0, deathSpinSpeed * Time.deltaTime);
        transform.position += new Vector3(deathxVel * Time.deltaTime, deathyVel * Time.deltaTime, 0);
        if (transform.position.y >= deathMaxHeight) {
          deathyVel *= -1;
        }
        if (dyingAnimTimer <= 0) {
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
    if (state == States.DYING || state == States.DESPAWNING) return;
    switch (otherTag) {
      case "Player":
        state = States.DESTROYABLE;
        break;
      case "Mom":
        state = States.DYING;
        break;
    }
  }

  protected virtual void calcScore(float beatPressed) {
    Debug.Log("Pressed on " + beatPressed);
    float beatDiff = (beatPressed - beat);
    Debug.Log("Beat diff " + beatDiff);
    float perfect_score = 300f;
    float score = perfect_score * (1 - (Math.Abs(beatDiff) - PERFECT_THRESHOLD) / (MISTIME_THRESHOLD - PERFECT_THRESHOLD));
    if (Math.Abs(beatDiff) < PERFECT_THRESHOLD) {
      Debug.Log("Perfect");
      scoreManager.UpdateScore(Mathf.RoundToInt(perfect_score));
    }
    else if (beatDiff > PERFECT_THRESHOLD && beatDiff < MISTIME_THRESHOLD) {
      Debug.Log("Late");
      scoreManager.UpdateScore(Mathf.RoundToInt(score));
    }
    else if (beatDiff < -PERFECT_THRESHOLD && beatDiff > -MISTIME_THRESHOLD) {
      Debug.Log("Early");
      scoreManager.UpdateScore(Mathf.RoundToInt(score));
    }
    else {
      Debug.Log("Miss");
    }
  }
}
