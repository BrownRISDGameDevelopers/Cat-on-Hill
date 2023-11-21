using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerControl : MonoBehaviour {
  public float timeBetweenAnimations = 1.5f;
  private float timeElapsed = 0;
  public Animator animator;

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space) == true) {
      animator.SetTrigger("SpacebarPressed");
    }
  }
}
