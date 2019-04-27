using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Input_Test : MonoBehaviour
{
    [Range(1,4)]
    [SerializeField] private int i_player_number = 1;

    private string s_player_number = "";

    private void Start()
    {
        s_player_number = i_player_number.ToString("");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Square_P" + s_player_number))
        {
            Debug.Log("Square_P" + s_player_number);
        }

        if (Input.GetButtonDown("R1_P" + s_player_number))
        {
            Debug.Log("R1_P" + s_player_number);
        }

        if(Input.GetAxis("R2_P" + s_player_number) > 0)
        {
            Debug.Log("R2_P" + s_player_number);
        }

        if (Input.GetAxis("L2_P" + s_player_number) > 0)
        {
            Debug.Log("L2_P" + s_player_number);
        }

        if (Input.GetAxis("Horizontal_P" + s_player_number) > 0)
        {
            Debug.Log("Horizontal_P" + s_player_number);
        }

        if (Input.GetAxis("Vertical_P" + s_player_number) > 0)
        {
            Debug.Log("Vertical_P" + s_player_number);
        }
    }
}
