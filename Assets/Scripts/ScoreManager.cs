using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int overall_score;
    // Start is called before the first frame update
    void Start()
    {
        overall_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score) {
        overall_score += score;
    }
}
