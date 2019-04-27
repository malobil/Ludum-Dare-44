using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }

    [Header("UIGame")]

    public GameObject g_pause;
    public GameObject g_finish;


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

    public void ShowPause()
    {
        g_pause.SetActive(true);
    }

    public void UnShowPause()
    {
        g_pause.SetActive(false);
    }

    public void ShowFinish()
    {
        g_finish.SetActive(true);
    }

    public void UnShowFinish()
    {
        g_finish.SetActive(false);
    }
}
