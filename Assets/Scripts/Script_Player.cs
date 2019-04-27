using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Player : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth = 100f;
    [SerializeField] private float m_usingLife = 1f;
    private float f_current_speed;
    private float f_max_speed;
    private float f_CurrentHealth = 0f;

    [Header("Timer")]

    [SerializeField] private float m_setTimer = 3f;
    private float f_current_timer;

    private bool m_isDriver = false;


    [Header("Switch")]

    bool b_want_to_switch;

    void Start()
    {
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


        if (Input.GetKeyDown("e"))
        {
            WantToSwitch();
        }

        if (Input.GetKeyDown("f") && f_CurrentHealth > 0f && !m_isDriver)
        {
            UsingHealth();
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
