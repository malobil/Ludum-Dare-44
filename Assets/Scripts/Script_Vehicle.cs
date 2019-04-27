using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Vehicle : MonoBehaviour
{
    [Header ("Switch")]

    [SerializeField] private List<Script_Player> l_player;
    [SerializeField] private List<Transform> l_transform_switch_target;

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

    public void VerifySwitchState()
    {
        if(m_ActualDriver.GetComponent<Script_Player>().ReturnSwitchBool() && m_ActualPassenger.GetComponent<Script_Player>().ReturnSwitchBool())
        {
            SwitchPlayer();
        }
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
    }

    public void AddLifeTodriver(float Life)
    {
        if (m_ActualDriver)
            m_ActualDriver.AddLife(Life);
    }
}
