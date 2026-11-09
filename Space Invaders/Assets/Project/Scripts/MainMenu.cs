using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button m_PlayButton;

    [SerializeField]
    private Button m_QuitButton;


    public Action PlayButtonButtonClicked;
    public Action QuitButtonButtonClicked;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_PlayButton.onClick.AddListener(OnPlayButtonClicked);
        m_QuitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        PlayButtonButtonClicked?.Invoke();
    }

    private void OnQuitButtonClicked()
    {
        QuitButtonButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        m_PlayButton.onClick.RemoveAllListeners();
        m_QuitButton.onClick.RemoveAllListeners();
    }

}
