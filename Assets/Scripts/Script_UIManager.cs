using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }

    [Header("UIGame")]
    public GameObject m_pauseMenu;
    public GameObject m_endGameMenu;
    public GameObject m_StartMenu;

    public Text m_LapP1;
    public Text m_LapP2;
    public Text WinText;

    public List<Script_Vehicle> cars;


    private int P1Lap = 1  ;
    private int P2Lap = 1;

    public Image m_P1Life;
    public Image m_P2Life;
    public Image m_P3Life;
    public Image m_P4Life;

    [Header ("Sounds")]

    private AudioSource a_audio_source;
    public AudioClip a_finish;
    public AudioClip a_final_lap;

    [Header("Start")]

    public GameObject g_player_1;
    public GameObject g_THOMAS;

    public Transform spawn_point;


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

    private void Start()
    {
        int i_spawn = Random.Range(0, 10);

        if(i_spawn <= 8)
        {
            Instantiate(g_player_1, spawn_point);
        }

        if(i_spawn > 8)
        {
            Instantiate(g_THOMAS, spawn_point);
        }
        

        a_audio_source = GetComponent<AudioSource>();
    }

    public void Starting()
    {
        foreach(Script_Vehicle a in cars)
        {
            a_audio_source.Play();
            a.CanMoveTrue();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void StopStart()
    {
        m_StartMenu.SetActive(false);
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
        Script_Audio_Manager.Instance.PlayAudioClip(a_finish);
        m_endGameMenu.SetActive(true);
        foreach (Script_Vehicle a in cars)
        {
            a.CanMoveFalse();
        }
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

            if (P1Lap >= 4)
            {
                ShowFinish();
                WinText.text = "Team 1 Wins";
            }

            if (P1Lap == 3)
            {
                Script_Audio_Manager.Instance.PlayAudioClip(a_final_lap);
            }

            m_LapP1.text = P1Lap.ToString();
            
        }

        if (player == 1)
        {

            P2Lap++;

            if (P2Lap >= 4)
            {
                ShowFinish();
                WinText.text = "Team 2 Wins";
                return;
            }

            if (P2Lap == 3)
            {
                Script_Audio_Manager.Instance.PlayAudioClip(a_final_lap);

            }

            m_LapP2.text = P2Lap.ToString();


            
        }
    }
}
