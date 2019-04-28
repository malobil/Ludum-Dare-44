using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Script_Vehicle : MonoBehaviour
{
    [Header("Switch")]

    [SerializeField] private List<Script_Player> l_player;
    [SerializeField] private List<Transform> l_transform_switch_target;

    private Script_Player m_ActualDriver = null;
    private Script_Player m_ActualPassenger = null;

    [SerializeField] private float f_add_heal_per_second;

    [SerializeField] private float f_speed_boost_speed = 500f;
    private CarController m_Car; // the car controller we want to use

    private bool b_can_lap = false;
    private bool b_can_move = true;

    [SerializeField] private int i_team = 0;

    public GameObject g_AttackCollider;
    public float f_DamagePassenger;

    void Start()
    {
        m_Car = transform.root.GetComponent<CarController>();
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            m_ActualDriver = l_player[0];
            m_ActualPassenger = l_player[1];
        }
        else
        {
            m_ActualDriver = l_player[1];
            m_ActualPassenger = l_player[0];
        }

        m_ActualDriver.BecomeDriver();
        m_ActualPassenger.BecomePassenger();

        m_ActualDriver.transform.position = l_transform_switch_target[0].position;
        m_ActualPassenger.transform.position = l_transform_switch_target[1].position;

    }

    private void Update()
    {
        if (b_can_move)
        {
            m_Car.Move(m_ActualDriver.GetCarMoveVariable().y, m_ActualDriver.GetCarMoveVariable().x, m_ActualDriver.GetCarMoveVariable().x, m_ActualDriver.GetCarMoveVariable().z);
        }

        m_ActualDriver.AddLife(f_add_heal_per_second * Time.deltaTime);
    }

    public void VerifySwitchState()
    {
        if (m_ActualDriver.GetComponent<Script_Player>().ReturnSwitchBool() && m_ActualPassenger.GetComponent<Script_Player>().ReturnSwitchBool())
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        Debug.Log("I switch");

        Script_Player passenger = m_ActualPassenger;
        Script_Player driver = m_ActualDriver;

        m_ActualPassenger = driver;
        m_ActualDriver = passenger;
        m_ActualPassenger.BecomeDriver();
        m_ActualDriver.BecomePassenger();

        m_ActualDriver.transform.position = l_transform_switch_target[0].position;
        m_ActualPassenger.transform.position = l_transform_switch_target[1].position;

    }

    public void AddLifeTodriver(float Life)
    {
        if (m_ActualDriver)
            m_ActualDriver.AddLife(Life);
    }

    public void AddSpeedMultiple()
    {
        m_Car.GetComponent<Rigidbody>().AddForce(m_Car.transform.forward * f_speed_boost_speed, ForceMode.Impulse);
        m_Car.ChangeMaxSpeed(f_speed_boost_speed);
    }

    public Script_Player GetCurrentDriver()
    {
        return m_ActualDriver;
    }

    public Script_Player GetCurrentPassenger()
    {
        return m_ActualPassenger;
    }


    public void CanLapTrue()
    {
        b_can_lap = true;
    }

    public void CanLapFalse()
    {
        b_can_lap = false;
    }

    public bool ReturnCanLap()
    {
        return b_can_lap;
    }

    public void CanMoveTrue()
    {
        b_can_move = true;
    }

    public void CanMoveFalse()
    {
        b_can_move = false;
    }

    public int ReturnTeamCar()
    {
        return i_team;
    }

    public void Attack()
    {
        g_AttackCollider.SetActive(true);
    }

    public void DamagePassenger()
    {
        m_ActualPassenger.RemoveLife(f_DamagePassenger);
    }
}
