using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_MainMenuManager : MonoBehaviour
{
    [Header("SceneManager")]

    public string s_game_scene;
    public GameObject g_play;

    public void Awake()
    {
        g_play.SetActive(false);    
    }

    public void Play()
    {
        g_play.SetActive(true);
        SceneManager.LoadScene(s_game_scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
