using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore
{
    public PlayerScore(int currentScore, int topScore, float scoreMultiplier)
    {
        CurrentScore = currentScore;
        TopScore = topScore;
        ScoreMultiplier = scoreMultiplier;
    }

    public int CurrentScore { get; set; }
    public int TopScore { get; set; }
    public float ScoreMultiplier { get; set; }

}
