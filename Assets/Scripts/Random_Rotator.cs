using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotator : MonoBehaviour
{
    public float tumble;
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
