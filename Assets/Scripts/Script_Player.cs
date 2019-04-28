using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;


public class Script_Player : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth = 100f;
    [SerializeField] private float m_usingLife = 2f;
    [SerializeField] private float m_usingLife_cd = 1f;

    private float m_current_usingLife_cd = 0f;
    private float f_current_speed;
    private float f_max_speed;
    private float f_CurrentHealth = 0f;

    [Header("Input")]
    [Range(1, 4)]
    [SerializeField] private int i_player_number = 1;

    private string s_controller_type = "";
    private string s_player_number = "";

    [Header("Timer")]

    [SerializeField] private float m_setTimer = 3f;
    private float f_switch_current_timer;

    public bool m_isDriver = false;


    [Header("Switch")]

    bool b_want_to_switch;
    public AudioClip a_hey_switch;

    private CarController m_Car; // the car controller we want to use
    private Script_Vehicle m_vehicle ; // the car controller we want to use

    private float acceleration = 0f;
    private float turn = 0f;
    private float drift = 0f;

    bool b_Attack_Cooldown = true;

    void Start()
    {
        m_vehicle = transform.root.GetComponent<Script_Vehicle>();

        if (Input.GetJoystickNames().Length > i_player_number - 1)
        {
            s_controller_type = Input.GetJoystickNames()[i_player_number - 1];
            s_player_number = i_player_number.ToString("");
        }

        f_CurrentHealth = m_MaxHealth;

    }

    void Update()
    {
        if (b_want_to_switch)
        {
            if (f_switch_current_timer > 0)
            {
                f_switch_current_timer -= Time.deltaTime;
            }
            else if (f_switch_current_timer <= 0)
            {
                b_want_to_switch = false; ;
            }
        }

        if(m_current_usingLife_cd > 0)
        {
            m_current_usingLife_cd -= Time.deltaTime;
        }

        turn = 0f;
        acceleration = 0f;
        drift = 0f;
       

        if (s_controller_type != "")
        {
            if (s_controller_type == "Wireless Controller")
            {
                if (m_vehicle.GetCurrentDriver() == this)
                {
                    float accelerateInput = Input.GetAxis("R2_P" + s_player_number);
                    float decelerateInput = Input.GetAxis("L2_P" + s_player_number);

                    if (Input.GetAxis("R2_P" + s_player_number) < 0)
                    {
                        accelerateInput = 0f;
                    }

                    if (Input.GetAxis("L2_P" + s_player_number) < 0)
                    {
                        decelerateInput = 0f;
                    }

                    acceleration = accelerateInput - decelerateInput;
                    turn = Input.GetAxis("Horizontal_P" + s_player_number);
                }
              

                if (Input.GetButtonDown("Square_P" + s_player_number))
                {
                    if (m_vehicle.GetCurrentPassenger() == this && b_Attack_Cooldown)
                    {
                        m_vehicle.Attack();
                        b_Attack_Cooldown = false;
                        StartCoroutine("WaitforAttack");
                    }
                }

                if (Input.GetButtonDown("R1_P" + s_player_number))
                {
                    WantToSwitch();
                }

                if (m_vehicle.GetCurrentPassenger() == this)
                {
                    if (Input.GetAxis("R2_P" + s_player_number) > 0)
                    {
                        UsingHealth();
                    }
                    else
                    {
                        m_vehicle.RemoveSpeedMultiple();
                    }
                }

                if (Input.GetAxis("L2_P" + s_player_number) > 0)
                {
                    Debug.Log("L2_P" + s_player_number);
                }

                if (Input.GetAxis("Horizontal_P" + s_player_number) > 0)
                {
                    Debug.Log("Horizontal_P" + s_player_number);
                }

                if (Input.GetAxis("Vertical_P" + s_player_number) > 0)
                {
                    Debug.Log("Vertical_P" + s_player_number);
                }
            }
            else
            {
                if (m_vehicle.GetCurrentDriver() == this)
                {
                    float accelerateInput = Input.GetAxis("RT_P" + s_player_number);
                    float decelerateInput = Input.GetAxis("LT_P" + s_player_number);

                    if (Input.GetAxis("RT_P" + s_player_number) < 0)
                    {
                        accelerateInput = 0f;
                    }

                    if (Input.GetAxis("LT_P" + s_player_number) < 0)
                    {
                        decelerateInput = 0f;
                    }

                    acceleration = accelerateInput - decelerateInput;
                    turn = Input.GetAxis("Horizontal_P" + s_player_number);
                }


                if (m_vehicle.GetCurrentPassenger() == this)
                {
                    if (Input.GetAxis("RT_P" + s_player_number) > 0)
                    {
                        UsingHealth();
                        Debug.Log("RT_P" + s_player_number);
                    }
                    else
                    {
                        m_vehicle.RemoveSpeedMultiple();
                    }
                }

                if (Input.GetAxis("LT_P" + s_player_number) > 0)
                {
                    Debug.Log("LT_P" + s_player_number);
                }

                if (Input.GetButtonDown("RB_P" + s_player_number))
                {
                    WantToSwitch();
                    Debug.Log("RB_P" + s_player_number);
                }

                if (Input.GetButtonDown("X_P" + s_player_number))
                {
                    if (m_vehicle.GetCurrentPassenger() == this && b_Attack_Cooldown)
                    {
                        m_vehicle.Attack();
                        b_Attack_Cooldown = false;
                        StartCoroutine("WaitforAttack");
                    }
                }

                if (Input.GetAxis("Horizontal_P" + s_player_number) > 0)
                {
                    Debug.Log("Horizontal_P" + s_player_number);
                }

                if (Input.GetAxis("Vertical_P" + s_player_number) > 0)
                {
                    Debug.Log("Vertical_P" + s_player_number);
                }
            }
        }
    }

    private void WantToSwitch()
    {
        f_switch_current_timer = m_setTimer;
        b_want_to_switch = true;
        transform.root.GetComponent<Script_Vehicle>().VerifySwitchState();
        Script_Audio_Manager.Instance.PlayAudioClip(a_hey_switch);
        Debug.Log("I one two switch");
    }

    public bool ReturnSwitchBool()
    {
        return b_want_to_switch;
    }

    private void UsingHealth()
    {
        if(f_CurrentHealth - m_usingLife > 0)
        {
            if (m_current_usingLife_cd <= 0)
            {
                f_CurrentHealth -= m_usingLife;
                transform.root.GetComponent<Script_Vehicle>().AddSpeedMultiple();
                m_current_usingLife_cd = m_usingLife_cd;
            }
        }
        else
        {
            m_vehicle.RemoveSpeedMultiple();
        }

        UpdateHealthUI();
    }

    public void AddLife(float LifeAdded)
    {
        if (LifeAdded + f_CurrentHealth >= m_MaxHealth)
            f_CurrentHealth = m_MaxHealth;
        else
            f_CurrentHealth += LifeAdded;

        UpdateHealthUI();
    }

    public void RemoveLife(float LifeRemoved)
    {
        if (f_CurrentHealth - LifeRemoved > 0)
        {
            f_CurrentHealth -= LifeRemoved;
        }
        else
        {
            f_CurrentHealth = 0;
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        switch(i_player_number)
        {
            case 1:
                Script_UIManager.Instance.UpdateP1Life(f_CurrentHealth);
                break;

            case 2:
                Script_UIManager.Instance.UpdateP2Life(f_CurrentHealth);
                break;

            case 3:
                Script_UIManager.Instance.UpdateP3Life(f_CurrentHealth);
                break;

            case 4:
                Script_UIManager.Instance.UpdateP4Life(f_CurrentHealth);
                break;
        }
    }

    public void BecomeDriver()
    {
        m_isDriver = true;
        b_want_to_switch = false;
    }

    public void BecomePassenger()
    {
        m_isDriver = false;
        b_want_to_switch = false;
    }

    public Vector3 GetCarMoveVariable()
    {
        return new Vector3(acceleration, turn, drift);
    }

    IEnumerator WaitforAttack()
    {
        yield return new WaitForSeconds(2f);
        b_Attack_Cooldown = true;
    }
}
