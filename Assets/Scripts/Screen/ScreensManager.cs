using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreensManager : MonoBehaviour
{
    #region Initialscreen

    [SerializeField] private GameObject initialScreen, settingsScreen;
    [SerializeField] private Button quitButton, startGamebutton, settingsButton;
    [SerializeField] private Button songButton, backinitialscreenButton;

    #endregion
    
    #region Pause

    [SerializeField] private GameObject pausePanel, hudPanel;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton, songPauseButton, quitGameButton;

    #endregion
    
    #region Lose

    [SerializeField] private GameObject losePanel;
    [SerializeField] private Button quitLoseButton, restartLoseButton;

    #endregion

    #region Win

    [SerializeField] private GameObject winPanel;
    [SerializeField] private Button quitWinButton, restartWinButton;

    #endregion

    #region Music

    [SerializeField] private Sprite withMusic, withoutMusic;

    public bool musicIsPlaying;
    
    #endregion

    #region HUD

    [SerializeField] private TMPro.TextMeshProUGUI lifesText;

    #endregion
       
    private void Awake()
    {
        int screenManager = FindObjectsOfType<ScreensManager>().Length;
        
        if (screenManager > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this);

        AssingButtons();
        musicIsPlaying = true;
    }

    private void Start()
    {
        
    }

    void AssingButtons()
    {
        quitButton.onClick.AddListener(QuitGame);
        startGamebutton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(ShowSettingsScreen);
        backinitialscreenButton.onClick.AddListener(ShowInitialScreen);
        
        songButton.onClick.AddListener(EnableOrDisableSong);
        songPauseButton.onClick.AddListener(EnableOrDisableSong);
        
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        quitGameButton.onClick.AddListener(BackToInitialScreen);

        quitLoseButton.onClick.AddListener(QuitGame);
        restartLoseButton.onClick.AddListener(RestartGame);

        quitWinButton.onClick.AddListener(QuitGame);
        restartWinButton.onClick.AddListener(RestartGame);
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
        //aqui
        musicIsPlaying = !musicIsPlaying;

        var spriteTochange = musicIsPlaying ? withMusic : withoutMusic;

        songButton.GetComponent<Image>().sprite = spriteTochange;
        songPauseButton.GetComponent<Image>().sprite = spriteTochange;
        GameManager.instance.PauseMusic(musicIsPlaying);
    }
    void StartGame()
    {
        SceneManager.LoadScene("Scenes/Game");
        hudPanel.SetActive(true);
        
        initialScreen.SetActive(false);
        settingsScreen.SetActive(false);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        GameManager.instance.PauseMusic(musicIsPlaying);
    }
    void RestartGame(){
        GameManager.instance.SetLife(GameManager.instance.GetMaxLife);
        GameManager.instance.SetDeersCollected(0);
        SceneManager.LoadScene("Scenes/Game");
        hudPanel.SetActive(true);
        
        initialScreen.SetActive(false);
        settingsScreen.SetActive(false);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void BackToInitialScreen()
    {
        SceneManager.LoadScene("Scenes/InitialScreen");
        
        initialScreen.SetActive(true);
        
        hudPanel.SetActive(false);
        settingsScreen.SetActive(false);
        pausePanel.SetActive(false);
    }

    void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        hudPanel.SetActive(false);
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        hudPanel.SetActive(false);
    }
    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        hudPanel.SetActive(false);
    }

    public void RefreshLifes(){
        lifesText.text = $"Vidas: {GameManager.instance.GetLife}";
    }

    void Resume()
    {
        Time.timeScale = 1;
        hudPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
