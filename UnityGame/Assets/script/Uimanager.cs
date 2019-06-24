using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    //  Score 
    public Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // updating score
        scoreText.text = "Score: " + score;
    }

    public void hitsPenalty()
    {
        score -= 10;
        Debug.Log(score);
    }
}
