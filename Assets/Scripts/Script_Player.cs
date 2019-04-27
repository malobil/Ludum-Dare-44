﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;


public class Script_Player : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth = 100f;
    [SerializeField] private float m_usingLife = 1f;
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

    private CarController m_Car; // the car controller we want to use

void Start()
    {
        m_Car = transform.root.GetComponent<CarController>();

        if (Input.GetJoystickNames().Length > i_player_number - 1)
        {
            s_controller_type = Input.GetJoystickNames()[i_player_number - 1];
            s_player_number = i_player_number.ToString("");
        }

        f_CurrentHealth = 20f;

    }

    /*void Update()
    {
        
    }*/

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

        float h = 0f;
        float v = 0f;
        float handbrake = 0f;
       

        if (s_controller_type != "")
        {
            if (s_controller_type == "Wireless Controller")
            {
                if (m_isDriver)
                {
                    AddLife(Time.deltaTime * 2);
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

                    v = accelerateInput - decelerateInput;
                    h = Input.GetAxis("Horizontal_P" + s_player_number);
                    m_Car.Move(h, v, v, handbrake);
                }
              

                if (Input.GetButtonDown("Square_P" + s_player_number))
                {
                    Debug.Log("Square_P" + s_player_number);
                }

                if (Input.GetButtonDown("R1_P" + s_player_number))
                {
                    WantToSwitch();
                    Debug.Log("R1_P" + s_player_number);
                }

                if (!m_isDriver)
                {
                    if (Input.GetAxis("R2_P" + s_player_number) > 0)
                    {
                        UsingHealth();
                        Debug.Log("R2_P" + s_player_number);
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
                if (m_isDriver)
                {
                    AddLife(Time.deltaTime * 2);
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

                    v = accelerateInput - decelerateInput;
                    h = Input.GetAxis("Horizontal_P" + s_player_number);
                    m_Car.Move(h, v, v, handbrake);
                }


                if (!m_isDriver)
                {
                    if (Input.GetAxis("RT_P" + s_player_number) > 0)
                    {
                        UsingHealth();
                        Debug.Log("RT_P" + s_player_number);
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
                    Debug.Log("X_P" + s_player_number);
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
        Debug.Log("I one two switch");
    }

    public bool ReturnSwitchBool()
    {
        return b_want_to_switch;
    }

    private void UsingHealth()
    {
        f_CurrentHealth -= m_usingLife;
    }

    public void AddLife(float LifeAdded)
    {
        if (LifeAdded + f_CurrentHealth >= m_MaxHealth)
            f_CurrentHealth = m_MaxHealth;
        else
            f_CurrentHealth += LifeAdded;
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
}
