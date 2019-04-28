using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DamageCollider : MonoBehaviour
{
    public AudioClip a_take_damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Script_Audio_Manager.Instance.PlayAudioClip(a_take_damage);
            other.transform.root.GetComponent<Script_Vehicle>().DamagePassenger();
            transform.root.GetComponent<Script_Vehicle>().AddLifeToPassenger(10);
        }
    }
}
