using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    //  Score 
    public Text scoreText;
    float score;

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
        score = -1;
        Debug.Log(score);
    }
    public void forwardReward()
    {
        score += 0.5f;
        Debug.Log(score);
    }
    public void XReward()
    {
        score += 0.2f;
        Debug.Log(score);
    }
}
