using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField]
    private Button m_MainMenuButton;


    public Action MainMenuButtonClicked;


    private void OnEnable()
    {
        m_MainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    private void OnDisable()
    {
        m_MainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnMainMenuButtonClicked()
    {
        MainMenuButtonClicked?.Invoke();
    }


}
