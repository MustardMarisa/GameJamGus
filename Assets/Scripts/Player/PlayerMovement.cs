using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    public float speed = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity = -19.52f;

    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        //obtenemos input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //paramos aceleracion en y (caida de gravedad) si ya estamos en el suelo)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //aplicamos movimiento
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        //aplicamos gravedora
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
