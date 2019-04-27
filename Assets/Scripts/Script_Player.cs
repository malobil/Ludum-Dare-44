using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    
    [SerializeField] private float f_acceleration;
    private float f_current_speed;
    private float f_max_speed;

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
        
    }

    void Update()
    {
        Accelerate();

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

    }
}
