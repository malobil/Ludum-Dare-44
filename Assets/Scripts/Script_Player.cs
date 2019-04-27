using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    
    [SerializeField] private float f_acceleration;
    [SerializeField] private float f_currentHealth;
    [SerializeField] private float f_usingLife = 1f;
    private float f_current_speed;
    private float f_max_speed;
    private float f_Health = 5f;


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
        f_currentHealth = f_Health;
    }

    void Update()
    {
        Accelerate();

        if(Input.GetKeyDown("e"))
        {
            WantToSwitch();
        }

        if(Input.GetKeyDown("f") && f_currentHealth > 0f)
        {
            UsingHealth();
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

    private void UsingHealth()
    {
        f_currentHealth -= f_usingLife;
        Debug.Log(f_currentHealth);
    }
}
