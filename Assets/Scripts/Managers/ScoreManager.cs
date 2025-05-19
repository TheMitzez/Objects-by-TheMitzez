using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int score;
    [SerializeField] private int highScore;

    public UnityEvent onScoreUpdate;
    public UnityEvent onHighScoreUpdate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        GameManager.GetInstance().OnGameStart += OnGameStart;
        onHighScoreUpdate?.Invoke();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void IncrementScore()
    {
        score++;
        onScoreUpdate?.Invoke();

        if (score > highScore)
        {
            highScore = score;
            onHighScoreUpdate?.Invoke();
        }
    }

    public void DeductScore()
    {
        score--;
        onScoreUpdate?.Invoke();
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void OnGameStart()
    {
        score = 0;
        onScoreUpdate?.Invoke();    
    }
}
