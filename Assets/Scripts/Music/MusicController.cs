using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "InitialScreen":
                GameManager.instance.SetMusicNowPlaying(GameManager.instance.GetMenuMusic);
                GameManager.instance.GetMusic.Play();
            break;
            case "Game":
                GameManager.instance.SetMusicNowPlaying(GameManager.instance.GetGameMusic);
                GameManager.instance.GetMusic.Play();
            break;
            case "EndGame":
                GameManager.instance.SetMusicNowPlaying(GameManager.instance.GetEndMusic);
                GameManager.instance.GetMusic.Play();
            break;
        }
    }
}
