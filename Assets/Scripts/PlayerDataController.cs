using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerDataController : MonoBehaviour
{
    private int _tempScore = 0;
    private PlayerScore _scoreController;

    private void Awake()
    {
        _scoreController = new PlayerScore(0, 0, 1);
    }

    public void SetCurrentScore(int value)
    {
        if(_tempScore > _scoreController.CurrentScore)
        {
            _scoreController.CurrentScore = value;
        }
    }

    public void RiseTempScore()
    {
        _tempScore++;
    }
}
