using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int AmountScore;
    private Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = AmountScore.ToString();
    }
    public void AddScore(int amount) 
    {
        AmountScore += amount;
        _scoreText.text = AmountScore.ToString();
    }
    public void SubstractScore(int amount) 
    {
        AmountScore -= amount;
        AmountScore = Mathf.Clamp(AmountScore, 0, 1000);
        _scoreText.text = AmountScore.ToString();
    }

}
