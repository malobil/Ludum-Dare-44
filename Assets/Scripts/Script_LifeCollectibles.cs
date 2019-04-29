using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LifeCollectibles : MonoBehaviour
{
    public float m_AmmountOfHeal;
    public AudioClip a_boost_power;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Script_Audio_Manager.Instance.PlayAudioClip(a_boost_power);
            other.transform.GetComponentInParent<Script_Vehicle>().AddLifeTodriver(m_AmmountOfHeal);
            transform.GetComponentInParent<Script_LifeCollectibles_Spawn>().ResetCD();
            Destroy(gameObject);
        }
    }
}
