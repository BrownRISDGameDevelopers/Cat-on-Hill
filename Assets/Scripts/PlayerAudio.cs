using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {
  private enum Sounds {
    WHIFF,
    HIT
  }
  private AudioSource sfxPlayer;
  public AudioClip whiffSound;
  public AudioClip hitSound;

  private Sounds sound2play;
  // Start is called before the first frame update
  void Start() {
    sfxPlayer = GetComponent<AudioSource>();
    sound2play = Sounds.WHIFF;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown("space")) {
      switch (sound2play) {
        case Sounds.WHIFF:
          sfxPlayer.PlayOneShot(whiffSound, 0.25f);
          break;
        case Sounds.HIT:
          sfxPlayer.PlayOneShot(hitSound, 0.25f);
          break;
      }
    }
  }
  private void OnTriggerEnter2D(Collider2D other) {
    string tag = other.tag;
    switch (tag) {
      case "Obstacle":
        sound2play = Sounds.HIT;
        break;
    }
  }
  private void OnTriggerExit2D(Collider2D other) {
    string tag = other.tag;
    switch (tag) {
      case "Obstacle":
        sound2play = Sounds.WHIFF;
        break;
    }
  }
}
