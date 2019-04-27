using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Vehicle : MonoBehaviour
{
    [Header ("Switch")]

    [SerializeField] private List<Script_Player> l_player;
    [SerializeField] private List<Transform> l_transform_switch_target;

    [Header("Vehicle")]

    [SerializeField] private float f_acceleration;
    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    private float f_current_speed;
    private float f_max_speed;

    private Script_Player m_ActualDriver = null;
    private Script_Player m_ActualPassenger = null;

    [SerializeField] private float f_add_heal_per_second;

    void Start()
    {
        int i = Random.Range(0, 2);
        Debug.Log(i);
        if (i == 0)
        {
            m_ActualDriver = l_player[0];
            m_ActualPassenger = l_player[1];
        }
        else
        {
            m_ActualDriver = l_player[1];
            m_ActualPassenger = l_player[0];
        }
        m_ActualDriver.BecomeDriver();
        m_ActualPassenger.BecomePassenger();
    }

    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            SwitchPlayer();
        }

        m_ActualDriver.AddLife(Time.deltaTime * 2);
    }

    public void VerifySwitchState()
    {
        foreach(Script_Player player in l_player)
        {
            if(player.ReturnSwitchBool())
            {
                SwitchPlayer();
            }  
        }
    }

    public void SwitchPlayer()
    {
        
    }

    public void AddLifeTodriver(float Life)
    {
        if (m_ActualDriver)
            m_ActualDriver.AddLife(Life);
    }
}
