using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Vehicle : MonoBehaviour
{
    [SerializeField] private List<GameObject> l_player;
    [SerializeField] private List<Transform> l_transform_switch_target;

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
}
