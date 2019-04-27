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

        m_ActualDriver.transform.position = l_transform_switch_target[0].position;
        m_ActualPassenger.transform.position = l_transform_switch_target[1].position;

    }

    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            SwitchPlayer();
        }

     
    }

    public void VerifySwitchState()
    {
        int a = 0;
        foreach(Script_Player player in l_player)
        {
            if(player.ReturnSwitchBool())
            {
                a++;
            }  
        }
        if (a == 2)
            SwitchPlayer();
    }

    public void SwitchPlayer()
    {
        if(l_player[0] == m_ActualDriver)
        {
            l_player[0] = m_ActualPassenger;
            l_player[1] = m_ActualDriver;
        }
        else
        {
            l_player[0] = m_ActualDriver;
            l_player[1] = m_ActualPassenger;
        }

        m_ActualDriver.transform.position = l_transform_switch_target[0].position;
        m_ActualPassenger.transform.position = l_transform_switch_target[1].position;
        m_ActualDriver.BecomeDriver();
        m_ActualPassenger.BecomePassenger();
        Debug.Log("Hey je suis le conducteur, lol");
    }

    public void AddLifeTodriver(float Life)
    {
        if (m_ActualDriver)
            m_ActualDriver.AddLife(Life);
    }
}
