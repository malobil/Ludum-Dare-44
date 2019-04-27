using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LifeCollectibles : MonoBehaviour
{
    public float m_AmmountOfHeal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.root.GetComponent<Script_Vehicle>().AddLifeTodriver(m_AmmountOfHeal);
            Destroy(gameObject);
        }
    }
}
