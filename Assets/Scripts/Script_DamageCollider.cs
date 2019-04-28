using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DamageCollider : MonoBehaviour
{
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
            other.transform.root.GetComponent<Script_Vehicle>().DamagePassenger();
            transform.root.GetComponent<Script_Vehicle>().AddLifeToPassenger(10);
        }
    }

    IEnumerator WaitforFade()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
