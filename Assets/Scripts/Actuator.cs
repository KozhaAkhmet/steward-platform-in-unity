using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Actuator : MonoBehaviour
{
    [Header("Reference Vectors")]
    public Transform basePlatform;
    public Transform platform;
    public Transform Pk;
    public Transform Bk;

    [Header("Vectors")]
    public Vector3 VectorPk;
    public Vector3 VectorBk;
    public Vector3 Lk;

    [Header("Parameters")]
    public Vector3 translation;
    public float Yaw;
    public float Pitch;
    public float Roll;
    private float length;


    public Controller controller;
    public GameObject inner;
    public GameObject outer;


    void Start()
    {
        // Base Anchor local position
        VectorBk = basePlatform.transform.position 
                    - Bk.transform.position;
                       
        //Platform Anchor local position
        VectorPk = platform.transform.position 
                    - Pk.transform.position;         
    }
    private void FixedUpdate()
    {
        Lk = (Quaternion.Euler(Yaw, Pitch, Roll) * VectorPk + translation) - VectorBk ; //Applying rotation and translation 

        // For Inner local position
        // When closed 0.6275051
        // When open 1.972953

        // For Lk.magnitude 
        // When closed 4.415061
        // When open 6.4162

        // Rearranging calculations
        length = map(Lk.magnitude, 4.415061f, 6.4162f, 0.6275051f, 1.972953f);

        // Applying lenght value
        inner.transform.localPosition = new Vector3(0, length, 0);
        Debug.Log(Lk.magnitude + "  " + (Pk.transform.position-Bk.transform.position).magnitude );
    }


    float map(float x, float in_min, float in_max,
                float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
