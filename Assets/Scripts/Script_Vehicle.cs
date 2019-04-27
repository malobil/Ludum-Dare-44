using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Vehicle : MonoBehaviour
{
    public static Script_Vehicle Instance { get; private set; }

    [SerializeField] private List<GameObject> l_player;
    [SerializeField] private List<Transform> l_transform_switch_target;

    [Header("Vehicle")]

    [SerializeField] private float f_acceleration;
    [SerializeField] private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    private float f_current_speed;
    private float f_max_speed;

    void Start()
    {
        
    }

    void Update()
    {
        
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

    public void Accelerate()
    {
        if (f_current_speed < f_max_speed)
        {

        }
    }
}
