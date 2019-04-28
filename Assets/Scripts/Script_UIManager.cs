using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }

    [Header("UIGame")]
    public GameObject m_pauseMenu;
    public GameObject m_endGameMenu;

    public Text m_LapP1;
    public Text m_LapP2;
    public Text WinText;

    private int P1Lap = 1;
    private int P2Lap = 1;

    public Image m_P1Life;
    public Image m_P2Life;
    public Image m_P3Life;
    public Image m_P4Life;


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
        m_pauseMenu.SetActive(true);
    }

    public void UnShowPause()
    {
        m_pauseMenu.SetActive(false);
    }

    public void ShowFinish()
    {
        m_endGameMenu.SetActive(true);
    }

    public void UnShowFinish()
    {      
        m_endGameMenu.SetActive(false);
    }

    public void UpdateP1Life(float life)
    {
        m_P1Life.fillAmount = life / 100;
    }

    public void UpdateP2Life(float life)
    {
        m_P2Life.fillAmount = life / 100;
    }

    public void UpdateP3Life(float life)
    {
        m_P3Life.fillAmount = life / 100;
    }

    public void UpdateP4Life(float life)
    {
        m_P4Life.fillAmount = life / 100;
    }

    public void UpdateLap(int player)
    {
        Debug.Log(player);
        if (player == 0)
        {
            P1Lap++;

            m_LapP1.text = P1Lap.ToString();
            if (P1Lap >= 3)
            {
                ShowFinish();
                WinText.text = "Team 1 Wins";
            }
        }

        if (player == 1)
        {
            P2Lap++;

            m_LapP2.text = P2Lap.ToString();
            if (P2Lap >= 3)
            {
                ShowFinish();
                WinText.text = "Team 2 Wins";
            }
        }
    }
}
