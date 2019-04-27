using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    [Header("Timer")]

    private float f_current_timer;
    [SerializeField] private float f_set_timer = 2f;
    
    [Header ("Vehicle")]

    [SerializeField] private float f_acceleration;
    [SerializeField] private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    private float f_current_speed;
    private float f_max_speed;
    [SerializeField] private float f_life;

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
        f_current_timer = f_set_timer;
    }

    void Update()
    {
        if(b_want_to_switch)
        {
            if(f_current_timer >= 0)
            {
                f_current_timer =- Time.deltaTime;

            }
            else if(f_current_speed < 0)
            {
                b_want_to_switch = false;
                f_current_timer = f_set_timer;
            }
        }

        if(Input.GetKeyDown("space"))
        {
            Accelerate();
        }

        if(Input.GetKeyDown("e"))
        {
            WantToSwitch();
        }
    }

    public void Accelerate()
    {
        if(f_current_speed < f_max_speed)
        {

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
}
