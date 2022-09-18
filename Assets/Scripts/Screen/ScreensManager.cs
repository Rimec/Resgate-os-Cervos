using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreensManager : MonoBehaviour
{
    #region Singleton

    private static ScreensManager instance;

    public static ScreensManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<ScreensManager>();

            return instance;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    #endregion

    [SerializeField] private GameObject initialScreen, settingsScreen;
    [SerializeField] private Button quitButton, startGamebutton, settingsButton;
    [SerializeField] private Button songButton, backinitialscreenButton;

    [SerializeField] private Sprite withMusic, withoutMusic;

    private bool musicIsPlaying;

    private void Awake()
    {
        AssingButtons();
        musicIsPlaying = true;
    }

    void AssingButtons()
    {
        quitButton.onClick.AddListener(QuitGame);
        startGamebutton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(ShowSettingsScreen);
        backinitialscreenButton.onClick.AddListener(ShowInitialScreen);
        
        songButton.onClick.AddListener(EnableOrDisableSong);
    }

    void ShowInitialScreen()
    {
        initialScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    void ShowSettingsScreen()
    {
        settingsScreen.SetActive(true);
        initialScreen.SetActive(false);
    }
    void EnableOrDisableSong()
    {
        musicIsPlaying = !musicIsPlaying;

        var spriteTochange = musicIsPlaying ? withMusic : withoutMusic;

        songButton.GetComponent<Image>().sprite = spriteTochange;
    }
    void StartGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
