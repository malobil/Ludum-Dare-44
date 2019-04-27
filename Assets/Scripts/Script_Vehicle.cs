using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Vehicle : MonoBehaviour
{
    public static Script_Vehicle Instance { get; private set; }

    [Header ("Switch")]

    [SerializeField] private List<GameObject> l_player;
    [SerializeField] private List<Transform> l_transform_switch_target;

    [Header("Vehicle")]

    [SerializeField] private float f_acceleration;
    [SerializeField] private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    private float f_current_speed;
    private float f_max_speed;

    private Script_Player m_ActualDriver = null;
    private Script_Player m_ActualPassenger = null;

    [SerializeField] private float f_add_heal_per_second;

    void Start()
    {
        
    }

    void Update()
    {
        m_ActualDriver.AddLife(f_add_heal_per_second);

        if(Input.GetKeyDown("a"))
        {
            SwitchPlayer();
        }
    }

    public void VerifySwitchState()
    {
        foreach(GameObject player in l_player)
        {
            if(player.GetComponent<Script_Player>().ReturnSwitchBool())
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
