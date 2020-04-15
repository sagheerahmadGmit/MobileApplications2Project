﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //variables
    public static int scoreValue = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        //get the text component
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //score to be displayed on screen on top right
        score.text = "Score: " + scoreValue;
    }
}
