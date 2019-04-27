using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LifeCollectibles_Spawn : MonoBehaviour
{
    public GameObject prefab;

    public float m_SpawnSpeed;

    private float m_actualCD;

    private void Start()
    {
        SpawnPrefab();
    }

    private void Update()
    {
        if (m_actualCD > 0f)
        {
            m_actualCD -= Time.deltaTime;
            if (m_actualCD <= 0f)
            {
                SpawnPrefab();
                m_actualCD = 0f;
            }
        }
    }

    public void SpawnPrefab()
    {
        Instantiate(prefab, transform);
    }

    public void ResetCD()
    {
        m_actualCD = m_SpawnSpeed;
    }
}
