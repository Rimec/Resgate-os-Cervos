using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int life = 3;
    private int maxLife = 3;
    private int deersColected = 0;
    private bool lost = false;
    private bool hasWon = false;
    [SerializeField] private int amountOfDeerInGame = int.MaxValue;
    private ScreensManager screensManager;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioClip menuMusic, gameMusic, endMusic;

    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        screensManager = FindObjectOfType<ScreensManager>();
        DontDestroyOnLoad(this.gameObject);
    }
    public void AddLife(int value){
        life += value;
        screensManager.RefreshLifes();
        if (life > maxLife)
        {
            life = maxLife;
        }
    }
    public void RemoveLife(int value){
        life -= value;
        screensManager.RefreshLifes();
        if (life <= 0)
        {
            life = 0;
            SetLost(true);
            SceneManager.LoadScene("Scenes/EndGame");
            screensManager.ShowLoseScreen();
        }
    }
    public void SetLife(int value){
        life = value;
        if (life > maxLife)
        {
            life = maxLife;
        }
        else if (life < 0)
        {
            life = 0;
        }
        screensManager.RefreshLifes();
    }
    public void AddDeersCollected(){
        deersColected++;
        if (deersColected == amountOfDeerInGame)
        {
            SetHasWon(true);
            SceneManager.LoadScene("Scenes/EndGame");
            screensManager.ShowWinScreen();
        }
    }
    public void SetDeersCollected(int value){
        deersColected = value;
    }
    public void SetAmountOfDeerInGame(int value){
        amountOfDeerInGame = value;
    }
    public void AddAmountOfDeerInGame(){
        amountOfDeerInGame++;
    }
    public void SetLost(bool value){
        lost = value;
    }
    public void SetHasWon(bool value){
        hasWon = value;
    }

    public void PauseMusic(bool value)
    {
        switch (value)
        {
            case true:
                music.mute = false;
                break;
            case false:
                music.mute = true;
                break;
        }
    }

    public void SetMusicNowPlaying(AudioClip np_music){
        music.clip = np_music;
    }
    public AudioSource GetMusic => music;
    public AudioClip GetMenuMusic => menuMusic;
    public AudioClip GetGameMusic => gameMusic;
    public AudioClip GetEndMusic => endMusic;
    public int GetLife => life;
    public int GetMaxLife => maxLife;
    public bool GetHasWon => hasWon;
    public bool GetLost => lost;
}
