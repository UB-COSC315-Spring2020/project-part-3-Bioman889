using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int pointValue = 200;
    public static int score;
    public static int minusScore = 50;
    public Text scoreText;

    void Update()
    {
        //sets ups the scoring. other scripts will effect this via the static variables
        scoreText.text = ("Score:    " + score);
    }
}
