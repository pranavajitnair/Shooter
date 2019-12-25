﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score,scoreHit=20;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText=GetComponent<Text>();
        scoreText.text=score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreHit(){
        score+=scoreHit;
        scoreText.text=score.ToString();
    }
}
