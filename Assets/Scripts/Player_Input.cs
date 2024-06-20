using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn1;
    public Transform[] shotSpawns;
    public float fireRate;
    public TouchPad touchPad;
    public FireTouch fire;

    private Quaternion caliberationQuaternion;
    private float nextFire;

    void Start()
    {
        CalliberateAccelometer(); 
    }

    void Update()
    {
        if(fire.CanFire() && Time.time > nextFire)
        {
           
            nextFire = Time.time + fireRate;
            Instantiate(shot,shotSpawn1.position,shotSpawn1.rotation);
            AudioSource audioData = GetComponent<AudioSource>();
            audioData.Play();
        }
        if(Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            AudioSource audioData = GetComponent<AudioSource>();
            audioData.Play();
        }
    }
    void FixedUpdate()
    {
        Vector2 direction = touchPad.GetDirection(); 

        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        Rigidbody player = GetComponent<Rigidbody>();
        player.velocity = movement * speed;

        player.position = new Vector3(
            Mathf.Clamp(player.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(player.position.z, boundary.minZ, boundary.maxZ));

        player.rotation = Quaternion.Euler(0.0f, 0.0f, player.velocity.x * -tilt);
    }

    void CalliberateAccelometer()
    {
        Vector3 accelarationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation
            (new Vector3(0.0f,0.0f,-1.0f),accelarationSnapshot);
        caliberationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAccelaration(Vector3 accelaration)
    { 
        Vector3 fixedAccelaration = caliberationQuaternion * accelaration;
         return fixedAccelaration;
    }

    [System.Serializable]
    public class Boundary
        {
        public float minX, maxX, minZ, maxZ;
        }
}
