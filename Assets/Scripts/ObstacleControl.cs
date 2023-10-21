using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {
  private bool destroyable;
  private bool dying;
  public float deathTimerSeconds;
  public Sprite deadSprite;
  // Start is called before the first frame update
  void Start() {
    destroyable = false;
    dying = false;
  }

  // Update is called once per frame
  void Update() {
    if (destroyable) {
      if (Input.anyKeyDown) {
        gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
        dying = true;
      }
    }
    if (dying) {
      deathTimerSeconds -= Time.deltaTime;
      if (deathTimerSeconds <= 0) {
        Destroy(gameObject);
      }
    }
  }
  private void OnTriggerEnter2D(Collider2D other) {
    tag = other.tag;
    switch (tag) {
      case "Player":
        destroyable = true;
        break;
    }
  }
}
