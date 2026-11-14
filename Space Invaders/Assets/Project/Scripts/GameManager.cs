using System;
using UnityEngine;


[Serializable]
public enum GameState { MainMenu, InGame, GameOver};

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int m_PointsPerKill = 10;


    [SerializeField]
    private EnemySpawner m_EnemySpawner;

    [SerializeField]
    private MainMenu m_MainMenu;

    [SerializeField]
    private GameHUD m_GameHUD;

    [SerializeField]
    private GameOverMenu m_GameOverMenu;

    [SerializeField]
    private GameObject m_Player;

    [SerializeField]
    private Transform m_PlayerSpawnPoint;

    public float Score { get; private set; }

    public static Action<float> OnScoreChange;
    public static Action<GameState> OnGameStateChange;

    public GameState CurrentGameState { get; private set; }

    private float m_GameTime = 0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetGameState(GameState.MainMenu);

        HealthComponent.OnDied += HandleOnDied;
        m_MainMenu.PlayButtonButtonClicked += HandleOnMainMenuPlayButtonClicked;
        m_GameOverMenu.MainMenuButtonClicked += HandleOnGameOverMenuMainMenuButtonClicked;

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentGameState == GameState.InGame)
        {
            m_GameTime += Time.deltaTime;
            SetEnemySpawnRate();
        }
        
    }

    public void SetEnemySpawnRate()
    {
        if (Time.time < 15f)
        {
            m_EnemySpawner.MinSpawnInterval = 0.9f;
            m_EnemySpawner.MaxSpawnInterval = 2f;
        }
        else if (Time.time < 35)
        {
            m_EnemySpawner.MinSpawnInterval = 0.6f;
            m_EnemySpawner.MaxSpawnInterval = 1.5f;
        }
        else if (Time.time < 60)
        {
            m_EnemySpawner.MinSpawnInterval = 0.3f;
            m_EnemySpawner.MaxSpawnInterval = 0.9f;
        }
    }

    public void HandleOnDied(HealthComponent healthComponent)
    {
        bool isEnemy = healthComponent.gameObject.CompareTag("Enemy");
        if (isEnemy)
        {
            Score += m_PointsPerKill;
            OnScoreChange?.Invoke(Score);
            return;
        }

        bool isPlayer = healthComponent.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            SetGameState(GameState.GameOver);
        }
    }


    public void SetGameState(GameState gameState)
    {
        if (gameState == GameState.InGame)
        {
            m_GameTime = 0f;
            CurrentGameState = GameState.InGame;
            m_EnemySpawner.enabled = true;
            m_MainMenu.gameObject.SetActive(false);
            m_GameHUD.gameObject.SetActive(true);

            GameObject player = Instantiate(m_Player, m_PlayerSpawnPoint.position, Quaternion.identity);
            if (player != null)
                m_GameHUD.Init(player);
        } 
        else if (gameState == GameState.GameOver)
        {
            CurrentGameState = GameState.GameOver;
            m_EnemySpawner.enabled = false;
            m_GameHUD.gameObject.SetActive(false);
            m_GameOverMenu.gameObject.SetActive(true);
        }
        else if (gameState == GameState.MainMenu)
        {
            CurrentGameState = GameState.MainMenu;
            m_EnemySpawner.enabled = false;
            m_MainMenu.gameObject.SetActive(true);
            m_GameHUD.gameObject.SetActive(false);
            m_GameOverMenu.gameObject.SetActive(false);

        }

        OnGameStateChange?.Invoke(CurrentGameState);
    }


    public void HandleOnMainMenuPlayButtonClicked()
    {
        SetGameState(GameState.InGame);
    }

    public void HandleOnGameOverMenuMainMenuButtonClicked()
    {
        SetGameState(GameState.MainMenu);
    }

    public void OnDestroy()
    {
        HealthComponent.OnDied -= HandleOnDied;
    }
}
