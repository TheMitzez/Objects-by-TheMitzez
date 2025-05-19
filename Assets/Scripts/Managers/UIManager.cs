using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private TMP_Text txtHealth;
    [SerializeField] private TMP_Text txtScore;
    [SerializeField] private TMP_Text txtHighScore;
    [SerializeField] private TMP_Text txtNukeCount;
    [SerializeField] private Image spreeTimer;
    [SerializeField] private GameObject spree;
    [SerializeField] private GameObject txtSpree;

    [Header("Menu")]
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject lblGameOverText;
    [SerializeField] private TMP_Text txtMenuHighScore;

    private float time = 3f;

    private Player player;
    private ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameManager.GetInstance().scoreManager;

        GameManager.GetInstance().OnGameStart += GameStarted;
        GameManager.GetInstance().OnGameOver += GameOver;

        UpdateHighScore();
    }

    private void Update()
    {
        try
        {
            if (player.HasBulletPickup())
            {
                spree.SetActive(true);
                time -= Time.deltaTime;
                spreeTimer.fillAmount = time / 3f;
            }
            else
            {
                spree.SetActive(false);
                spreeTimer.fillAmount = 1f;
                time = 3f;
            }
        }
        catch
        {
            return;
        }

        UpdateNukeCount();
    }
    public void UpdateNukeCount()
    {
        txtNukeCount.SetText(player.NukeCount().ToString());
    }
    public void Spree()
    {
        txtSpree.SetActive(true);
    }
    public void SpreeOff()
    {
        txtSpree.SetActive(false);
    }
    public void UpdateHealth(float currentHealth)
    {
        txtHealth.SetText(currentHealth.ToString("f0"));
    }

    public void UpdateScore()
    {
        txtScore.SetText(scoreManager.GetScore().ToString());
    }

    public void UpdateHighScore()
    {
        txtHighScore.SetText(scoreManager.GetHighScore().ToString());
        txtMenuHighScore.SetText($"High Score : {scoreManager.GetHighScore()}");
    }

    public void GameStarted()
    {
        player = GameManager.GetInstance().GetPlayer();
        player.health.onHealthUpdate += UpdateHealth;

        menuCanvas.SetActive(false);

    }

    public void GameOver()
    {
        lblGameOverText.SetActive(true);
        menuCanvas.SetActive(true);
    }

    public void Instructions()
    {
        panel.SetActive(false);
        instructions.SetActive(true);
    }

    public void Return()
    {
        panel.SetActive(true);
        instructions.SetActive(false);
    }
}
