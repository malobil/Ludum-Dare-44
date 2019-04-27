using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    [SerializeField] private float f_acceleration;
    [SerializeField] private float f_MaxHealth;
    [SerializeField] private float f_usingLife = 1f;
    private float f_current_speed;
    private float f_max_speed;
    private float f_CurrentHealth = 0f;

    [Header("Timer")]

    [SerializeField] private float f_set_timer = 3f;
    private float f_current_timer;


    [Header("Switch")]

    public bool b_want_to_switch;


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

    void Start()
    {
        f_CurrentHealth = f_MaxHealth;
        f_current_timer = f_set_timer;
    }

    void Update()
    {
        if(b_want_to_switch)
        {
            if(f_current_timer > 0)
            {
                f_current_timer = -Time.deltaTime;
            }
            else if (f_current_timer < 0)
            {
                b_want_to_switch = false; ;
                f_current_timer = f_set_timer;
            }
        }

        if(Input.GetKeyDown("space"))
        {
            Script_Vehicle.Instance.Accelerate();
        }

        if(Input.GetKeyDown("e"))
        {
            WantToSwitch();
        }

        if(Input.GetKeyDown("f") && f_CurrentHealth > 0f)
        {
            UsingHealth();
        }
    }

    private void WantToSwitch()
    {
        b_want_to_switch = true;
    }

    public bool ReturnSwitchBool()
    {
        return b_want_to_switch;
    }

    private void UsingHealth()
    {
        f_CurrentHealth -= f_usingLife;
        Debug.Log(f_CurrentHealth);
    }

    public void AddLife(float LifeAdded)
    {
        if (LifeAdded + f_CurrentHealth >= f_MaxHealth)
            f_CurrentHealth = f_MaxHealth;
        else
            f_CurrentHealth += LifeAdded;
    }
}
