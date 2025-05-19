using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Entities")]
    [SerializeField] private GameObject[] tempEnemy;
    [SerializeField] private Transform[] spawnPositions;

    [Header("Game Variables")]
    [SerializeField] private float enemySpawnRate;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject explosionPrefab;

    [Header("Audio")]
    [SerializeField] private AudioSource music;
    public AudioSource deathSound;
    public AudioSource explosion;
    public AudioSource spreeSound;

    private bool isEnemySpawning;
    private static GameManager instance;
    private Player player;
    private bool isPlaying;
    private bool enemyEscalate;

    public Action OnGameStart;
    public Action OnGameOver;
    
    public ScoreManager scoreManager;
    public PickupSpawner pickupSpawner;
    public UIManager uiManager;

    public static GameManager GetInstance()
    {
        return instance;
    }

    void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    private void Awake()
    {
        SetSingleton();   
    }

    private void Update()
    {
        if (enemySpawnRate >= 5.0f)
        {
            enemyEscalate = false;
            enemySpawnRate = 5.0f;
        }
    }
    void CreateEnemy()
    {
        int randomEnemy = UnityEngine.Random.Range(0, tempEnemy.Length);
        Transform spawnPoints = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)]; 
        Instantiate(tempEnemy[randomEnemy], spawnPoints.position, spawnPoints.rotation);
    }

    //Continously using coroutine
    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f / enemySpawnRate);
            CreateEnemy();
        }
    }
    IEnumerator EnemySpawnRate()
    {
       while (enemyEscalate)
        {
            yield return new WaitForSeconds(15.0f);
            enemySpawnRate = enemySpawnRate + 0.4f;
        }
    }
    public void SetEnemySpawnState(bool status)
    {
        isEnemySpawning = status;
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickupSpawner.SpawnPickup(enemy.transform.position);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public UIManager GetUI()
    {
        return uiManager;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        //Create the player
        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        player.OnDeath += StopGame;
        enemySpawnRate = 0.2f;
        isPlaying = true;
        music.Play();
        music.loop = true;

        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2.0f);
        isEnemySpawning = true;
        enemyEscalate = true;

        StartCoroutine(EnemySpawner());
        StartCoroutine(EnemySpawnRate());
    }
    public void StopGame()
    {
        isEnemySpawning = false;
        deathSound.Play();
        scoreManager.SetHighScore(); 
        music.Stop();
        StartCoroutine(GameStopper());
        StopCoroutine(EnemySpawnRate());  
    }

    IEnumerator GameStopper()
    {
        isEnemySpawning = false;
        yield return new WaitForSeconds(2);
        isPlaying = false;

        //Delete all enemies
        foreach (Enemy item in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
        {
            Destroy(item.gameObject);
        }

        //Delte all pickups
        foreach (Pickup item in FindObjectsByType<Pickup>(FindObjectsSortMode.None))
        {
            Destroy(item.gameObject);
        }

        OnGameOver?.Invoke();
    }

    // Particles
    public void Explosion()
    {
        GameObject clone = Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
        Destroy(clone, 3.0f);
    }
}
