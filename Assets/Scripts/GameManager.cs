using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void AddLife(int value){
        life += value;
        if (life > maxLife)
        {
            life = maxLife;
        }
    }
    public void RemoveLife(int value){
        life -= value;
        if (life <= 0)
        {
            life = 0;

            SetLost(true);
            SceneManager.LoadScene("Scenes/EndGame");
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
    }
    public void AddDeersCollected(){
        deersColected++;
        if (deersColected == amountOfDeerInGame)
        {
            SetHasWon(true);
            SceneManager.LoadScene("Scenes/EndGame");
        }
    }
    public void SetDeersCollected(int value){
        deersColected = value;
    }
    public void SetAmountOfDeerInGame(int value){
        amountOfDeerInGame = value;
    }
    public int GetMaxLife => maxLife;
    public bool GetHasWon => hasWon;
    public bool GetLost => lost;
    public void SetLost(bool value){
        lost = value;
    }
    public void SetHasWon(bool value){
        hasWon = value;
    }
}
