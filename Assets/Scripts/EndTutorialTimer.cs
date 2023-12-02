using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorialTimer : MonoBehaviour {
  public float tutorialTime;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    tutorialTime -= Time.deltaTime;
    if (tutorialTime <= 0) {
      FadeTransition transitioner = GetComponent<FadeTransition>();
      AudioSource bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
      transitioner.MoveToScene(6);
      fadeAudio(bgm);
    }
  }

  void fadeAudio(AudioSource audio) {
    if (audio.volume > 0.07f) {
      audio.volume -= 0.05f * Time.deltaTime;
    }
    else {
      audio.Stop();
    }
  }
}
