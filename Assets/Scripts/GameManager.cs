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
    [SerializeField] private int amountOfDeerInGame = int.MaxValue;
    private void Start(){
        amountOfDeerInGame = GameObject.FindGameObjectsWithTag("Deer").Length;
    }
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
        if (life < 0)
        {
            life = 0;
            SceneManager.LoadScene("LoseGame");
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
    }
}
