using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int _score;

    public void IncreaseScore(int amountToIncrease)
    {
        _score += amountToIncrease;
        Debug.Log($"Score is now: {_score}");
    }
}
