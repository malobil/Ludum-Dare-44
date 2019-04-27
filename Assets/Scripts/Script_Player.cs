using System.Collections;
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
    private float f_current_timer;

    private bool m_isDriver = false;


    [Header("Switch")]

    bool b_want_to_switch;

    private CarController m_Car; // the car controller we want to use


    private void Awake()
    {
        // get the car controller
       
    }

    void Start()
    {
        m_Car = GetComponent<CarController>();
        Debug.Log(m_Car);
        if (Input.GetJoystickNames().Length > i_player_number - 1)
        {
            s_controller_type = Input.GetJoystickNames()[i_player_number - 1];
            s_player_number = i_player_number.ToString("");
            Debug.Log(s_controller_type + " controller nb " + i_player_number);

        }

        f_CurrentHealth = 20f;
        f_current_timer = m_setTimer;
    }

    void Update()
    {
        if (b_want_to_switch)
        {
            if (f_current_timer > 0)
            {
                f_current_timer = -Time.deltaTime;
            }
            else if (f_current_timer < 0)
            {
                b_want_to_switch = false; ;
                f_current_timer = m_setTimer;
            }
        }
    }

    void FixedUpdate()
    {
        float h = 0f;
        float v = 0f;
        float handbrake = 0f;
       

        if (s_controller_type != "")
        {
            if (s_controller_type == "Wireless Controller")
            {
                v = Input.GetAxis("R2_P" + s_player_number) + 1;
                h = Input.GetAxis("Horizontal_P" + s_player_number);

                if (Input.GetButtonDown("Square_P" + s_player_number))
                {
                    Debug.Log("Square_P" + s_player_number);
                }

                if (Input.GetButtonDown("R1_P" + s_player_number))
                {
                    WantToSwitch();
                    Debug.Log("R1_P" + s_player_number);
                }

                if (Input.GetAxis("R2_P" + s_player_number) > 0)
                {
                    // UsingHealth();
                    Debug.Log("R2_P" + s_player_number);
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
                v = Input.GetAxis("RT_P" + s_player_number);
                h = Input.GetAxis("Horizontal_P" + s_player_number);

                if (Input.GetAxis("RT_P" + s_player_number) > 0)
                {
                    // UsingHealth();
                    Debug.Log("RT_P" + s_player_number);
                }

                if (Input.GetAxis("LT_P" + s_player_number) > 0)
                {
                    Debug.Log("RT_P" + s_player_number);
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
            Debug.Log(h);
            Debug.Log(v);
            m_Car.Move(h, v, v, handbrake);
        }
    }

    private void WantToSwitch()
    {
        b_want_to_switch = true;
        transform.root.GetComponent<Script_Vehicle>().VerifySwitchState();
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
    }

    public void BecomePassenger()
    {
        m_isDriver = false;
    }
}
