using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Input_Test : MonoBehaviour
{
    [Range(1,4)]
    [SerializeField] private int i_player_number = 1;

    private string s_controller_type = "" ;
    private string s_player_number = "";

    private void Start()
    {        
        if (Input.GetJoystickNames().Length > i_player_number - 1)
        {
            s_controller_type = Input.GetJoystickNames()[i_player_number -1];
            s_player_number = i_player_number.ToString("");
            Debug.Log(s_controller_type + " controller nb " + i_player_number);
           
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(s_controller_type != "")
        {
            if (s_controller_type == "Wireless Controller")
            {
                if (Input.GetButtonDown("Square_P" + s_player_number))
                {
                    Debug.Log("Square_P" + s_player_number);
                }

                if (Input.GetButtonDown("R1_P" + s_player_number))
                {
                    Debug.Log("R1_P" + s_player_number);
                }

                if (Input.GetAxis("R2_P" + s_player_number) > 0)
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
            else
            {
                if (Input.GetAxis("RT_P" + s_player_number) > 0)
                {
                    Debug.Log("RT_P" + s_player_number);
                }

                if (Input.GetAxis("LT_P" + s_player_number) > 0)
                {
                    Debug.Log("RT_P" + s_player_number);
                }

                if (Input.GetButtonDown("RB_P" + s_player_number))
                {
                    Debug.Log("RB_P" + s_player_number);
                }

                if (Input.GetButtonDown("X_P" + s_player_number))
                {
                    Debug.Log("X_P" + s_player_number);
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
    }
           
}
