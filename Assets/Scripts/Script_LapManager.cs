using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LapManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform.root.GetComponent<Script_Vehicle>().ReturnCanLap())
            {
                Script_UIManager.Instance.UpdateLap(other.transform.root.GetComponent<Script_Vehicle>().ReturnTeamCar());
            }
        }
    }
}
