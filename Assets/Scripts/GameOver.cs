using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : Overlay
{
    public static string SCORE_NAME = "Score";

    public Text scoreboard;
    public string scoreboardFormat;

    private void Awake()
    {
        scoreboard = transform.Find("Overlay").Find(SCORE_NAME).gameObject.GetComponent<Text>();

        scoreboardFormat = scoreboard.text;
    }

    public void SetScore(Score score)
    {
        scoreboard.text = string.Format(scoreboardFormat, score.Trees, score.Time);
    }
}
