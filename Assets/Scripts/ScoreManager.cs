using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int overall_score;
    public TextMeshProUGUI scoreText;
    public float percentPerfectScore; //TODO
    // Start is called before the first frame update
    void Start()
    {
        overall_score = 0;
        scoreText.text = "SCORE " + overall_score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score) {
        overall_score += score;
        scoreText.text = "SCORE " + overall_score.ToString();
    }

    //TODO
    public void PlayParticles() {
        print(":P");
    }
}
