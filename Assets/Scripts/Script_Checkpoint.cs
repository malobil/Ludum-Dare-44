using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.root.GetComponent<Script_Vehicle>().CanLapTrue();
        }
    }
}
