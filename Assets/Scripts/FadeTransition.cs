using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour {

  public Animator animator;
  public float transitionTime = 0.5f;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void MoveToScene(int sceneID) {
    SceneManager.LoadScene(sceneID);
    //StartCoroutine(SceneTransition(sceneID));
  }

  IEnumerator SceneTransition(int sceneID) {
    animator.SetTrigger("Start");

    yield return SceneManager.LoadSceneAsync(sceneID); ;
  }
}
