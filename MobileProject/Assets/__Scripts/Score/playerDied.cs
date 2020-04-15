using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerDied : MonoBehaviour
{
    //variables and text used
    public static int highScore = 0;
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
        //print the text out on the screen with the score
        score.text = "" + DamageHandler.highScore;
    }
}
