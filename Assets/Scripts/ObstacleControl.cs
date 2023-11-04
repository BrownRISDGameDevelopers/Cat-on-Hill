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
  private float deathxVel;
  private float deathyVel;
  private float deathSpinSpeed;
  private float deathMaxHeight;
  public ParticleSystem deathParticleSystem;

  // Start is called before the first frame update
  protected virtual void Start() {
    state = States.UNINTERACTABLE;
    // beat gives us the starting x position, offset b/c character starts at -7.04
    transform.position = new Vector3(beat - 3.04f, transform.position.y, transform.position.z);
    deathxVel = -12.5f;
    deathyVel = 12.5f;
    deathSpinSpeed = 2250f;
    deathMaxHeight = 4f;
  }

  // Update is called once per frame
  protected virtual void Update() {
    switch (state) {
      case States.DESTROYABLE:
        if (Input.GetKey("space")) {
          gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
          // var em = deathParticleSystem.emission;
          // em.enabled = true;
          // deathParticleSystem.Play();
          state = States.DYING;
        }
        break;
      case States.DYING:
        timerToChangeSprite -= Time.deltaTime;
        transform.Rotate(0, 0, deathSpinSpeed * Time.deltaTime);
        transform.position += new Vector3(deathxVel * Time.deltaTime, deathyVel * Time.deltaTime, 0);
        if (transform.position.y >= deathMaxHeight) {
          deathyVel *= -1;
        }
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
