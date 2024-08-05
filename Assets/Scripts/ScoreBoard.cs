using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int _score;
    TMP_Text _scoreText;

    void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreText.text = $"Score: {_score}";
    }
    
    public void IncreaseScore(int amountToIncrease)
    {
        _score += amountToIncrease;
        _scoreText.text = $"Score: {_score}";
    }
}
