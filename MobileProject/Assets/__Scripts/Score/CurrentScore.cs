﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    public static int currentScore = 0;
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
        //score to be displayed on game over screen
        score.text = "" + DamageHandler.newScore;
    }
}
