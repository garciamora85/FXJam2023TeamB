using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    //Velocidad Rotar
    public float RotationSpeed = 1f;
    //Velocidad Palante
    public float MovementSpeed = 1f;
    //Velocidad Patras
    public float BackwardsSpeed = 0.5f;

    public AudioSource steps;
    public AudioSource hit;

    private CharacterController character_controller;
    private Vector3 input;
    private Vector3 rotation;
    //private float gravity = -9.82f;
    // Start is called before the first frame update
    private void Start()
    {
        character_controller = gameObject.GetComponent<CharacterController>();
        
    }


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
        {
            hit.Play();
            input *= 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 forward = this.transform.forward;
        input = new Vector3(0, 0, Input.GetAxis("Vertical")) * -1;

        if (input.z >= 0)
        {
            input *= MovementSpeed;
        }
        else
        {
            input *= BackwardsSpeed;
        }

        input = forward * input.z;
        character_controller.Move(input * Time.deltaTime);
        
        rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * RotationSpeed * Time.deltaTime, 0) + transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = Quaternion.Euler(rotation);

        if (input.magnitude > 0)
        {
            steps.volume = 1;
        }else steps.volume = 0;
    }
}
