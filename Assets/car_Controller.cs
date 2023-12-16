using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class car_Controller : MonoBehaviour
{
    public WheelCollider frontLeftWheel, frontRightWheel;
    public WheelCollider rearLeftWheel, rearRightWheel;
    public float maxTorque;
    public Vector3 respawn;
    public Vector3 StartPos;
    public Quaternion respawnRot;
    private Rigidbody rb;
    public int Lap;
    public int Coins;

    void Start()
    {
        respawn = transform.position;
        StartPos = transform.position;
        respawnRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        Lap = 1;
        Coins = 0;
    }

    void Update()
    {
        
        float torque = maxTorque * Input.GetAxis("Vertical");



        frontLeftWheel.motorTorque = torque;
        frontRightWheel.motorTorque = torque;


        float steerAngle = 30f * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

        if (Input.GetKeyDown("r"))
        {
            RestartCar();
        }

        if (Lap > 1)
        {
            EndGame();
        }
    }

    public void RestartCar()
    {
        transform.position = respawn;
        transform.rotation = respawnRot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void EndGame()
    {
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshRenderer>() != null)
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
            {
                respawn = transform.position;
                respawnRot = transform.rotation;
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.black)
            {
                if (StartPos != respawn)
                {
                    Lap += 1;
                }
            }
        }
    }
}
