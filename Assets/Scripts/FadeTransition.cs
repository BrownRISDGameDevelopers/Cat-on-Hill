using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour {

  public Animator animator;
  public float transitionTime;

  public AudioSource audioSource;

  public int sceneID;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (audioSource != null) {
      if (!audioSource.isPlaying) {
        MoveToScene(sceneID);
      }
    }
  }

  public void MoveToScene(int sceneID) {
    StartCoroutine(SceneTransition(sceneID));
  }

  IEnumerator SceneTransition(int sceneID) {
    animator.SetTrigger("Start");
    yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene(sceneID);
  }
}
