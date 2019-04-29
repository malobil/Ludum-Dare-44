using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LapManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lap");
        if (other.CompareTag("Player"))
        {
            if (other.transform.GetComponentInParent<Script_Vehicle>().ReturnCanLap())
            {
                Debug.Log("Lap OK");
                Script_UIManager.Instance.UpdateLap(other.transform.root.GetComponent<Script_Vehicle>().ReturnTeamCar());
                other.transform.GetComponentInParent<Script_Vehicle>().CanLapFalse();
            }
        }
    }
}
