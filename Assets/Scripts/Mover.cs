using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    void Start()
    {
      Rigidbody bolt = GetComponent<Rigidbody>();
      bolt.velocity = transform.forward * speed;
    }
}
