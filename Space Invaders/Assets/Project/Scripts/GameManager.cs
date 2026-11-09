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
    private GameObject m_Player;

    public float Score { get; private set; }

    public static Action<float> OnScoreChange;

    public GameState CurrentGameState { get; private set; }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetGameState(GameState.MainMenu);

        HealthComponent.OnDied += HandleOnDied;
        m_MainMenu.PlayButtonButtonClicked += HandleOnMainMenuPlayButtonClicked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Score: {Score}");
    }

    public void HandleOnDied(HealthComponent healthComponent)
    {
        bool isEnemy = healthComponent.gameObject.CompareTag("Enemy");
        if (isEnemy)
        {
            Score += m_PointsPerKill;
            OnScoreChange?.Invoke(Score);
        }
    }


    public void SetGameState(GameState gameState)
    {
        if (gameState == GameState.InGame)
        {
            CurrentGameState = GameState.InGame;
            m_EnemySpawner.enabled = true;
            m_Player.SetActive(true);
            m_MainMenu.gameObject.SetActive(false);
        } 
        else if (gameState == GameState.GameOver)
        {

        }
        else if (gameState == GameState.MainMenu)
        {
            CurrentGameState = GameState.MainMenu;
            m_EnemySpawner.enabled = false;
            m_Player.SetActive(false);
            m_MainMenu.gameObject.SetActive(true);

        }
    }


    public void HandleOnMainMenuPlayButtonClicked()
    {
        SetGameState(GameState.InGame);
    }

    public void OnDestroy()
    {
        HealthComponent.OnDied -= HandleOnDied;
    }
}
