using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_ScoreTextNumber;

    [SerializeField]
    Scrollbar m_HealthBar;

    private HealthComponent m_PlayerHealthComponent;


    private void OnEnable()
    {
        GameManager.OnScoreChange += HandleOnScoreChange;
        GameManager.OnGameStateChange += HandleOnGameStateChange;
    }

    private void OnDisable()
    {
        GameManager.OnScoreChange -= HandleOnScoreChange;
        GameManager.OnGameStateChange -= HandleOnGameStateChange;
    }

    public void Init(GameObject player)
    {
        m_PlayerHealthComponent = player.GetComponent<HealthComponent>();
        if (m_PlayerHealthComponent != null )
        {
            m_HealthBar.size = m_PlayerHealthComponent.CurrentHealth / m_PlayerHealthComponent.MaxHealth;
            m_PlayerHealthComponent.OnHealthChange += HandleOnPlayerHealthChange;
        }
    }

    public void HandleOnScoreChange(float newScore)
    {
        m_ScoreTextNumber.SetText($"{newScore}");
    }

    public void HandleOnGameStateChange(GameState gameState)
    {
        if (gameState == GameState.InGame)
        {
            m_ScoreTextNumber.SetText("0");
        }
    }

    public void HandleOnPlayerHealthChange(float newHealth, float maxHealth)
    {
        Debug.Log("HUD Event");

        m_HealthBar.size = newHealth / maxHealth;
        if (newHealth <= 0f)
        {
            m_PlayerHealthComponent.OnHealthChange -= HandleOnPlayerHealthChange;
        }
    }





}
