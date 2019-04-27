using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DontComeBack : MonoBehaviour
{
    private List<GameObject> l_player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            l_player.Add(other.gameObject);
        }
    }
}
