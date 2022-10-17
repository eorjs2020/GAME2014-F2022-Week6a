using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private TMP_Text scoreLable;

    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
        scoreLable = GameObject.Find("ScoreLabel").GetComponent<TMP_Text>();
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
