using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Check");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Check OK");
            other.transform.root.GetComponent<Script_Vehicle>().CanLapTrue();
        }
    }
}
