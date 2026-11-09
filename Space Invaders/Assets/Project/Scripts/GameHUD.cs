using TMPro;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_ScoreTextNumber;


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




}
