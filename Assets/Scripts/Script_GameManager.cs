using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{
    public static Script_GameManager Instance { get; private set; }

    [Header("GameState")]
    private bool b_pause;
    private bool b_finish;

    [Header("LevelManager")]
    public string s_menu_scene;

    private List<GameObject> g_vehicle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    public void Finish()
    {
        Pause();
        Script_UIManager.Instance.ShowFinish();
    }

    public void Pause()
    {
        if(!b_pause)
        {
            Script_UIManager.Instance.ShowPause();
            Time.timeScale = 0.001f;
        }
        else if(b_pause)
        {
            Script_UIManager.Instance.UnShowPause();
            Time.timeScale = 1f;
        }
    }

    public bool GetPauseBool()
    {
        return b_pause;
    }

    public void RestartGame()
    {
        Script_UIManager.Instance.UnShowFinish();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(s_menu_scene);
    }
}
