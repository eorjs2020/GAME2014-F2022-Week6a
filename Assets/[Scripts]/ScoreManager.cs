using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreLable;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
        
    }

   
    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreLable();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreLable();
    }

    public void UpdateScoreLable()
    {
        scoreLable.text = $"Score : {score}";
    }
}
