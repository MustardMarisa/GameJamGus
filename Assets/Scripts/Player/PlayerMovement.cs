using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Sonidos footsteps")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private float sprintMultiplier = 0.6f;
    [SerializeField] private AudioSource footstepsAudioSource = default;
    [SerializeField] private AudioClip[] stepsClips = default;
    private float footstepTimer = 0;
    //private float GetCurrentOffset => baseStepSpeed || baseStepSpeed *sprintMultiplier

    public gMapa mapa;

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

        //aplicamos sonido
        footstepTimer -= Time.deltaTime;
        if(footstepTimer <= 0 && (x>0||z>0))
        {
            footstepsAudioSource.PlayOneShot(stepsClips[Random.Range(0, stepsClips.Length - 1)]);
            footstepTimer = baseStepSpeed;
            if (speed == 5)
            {
                footstepTimer = baseStepSpeed * sprintMultiplier;
            }
        }
        
        //aplicamos gravedora
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            //Logica de Gus
            //mapa = FindObjectOfType<gMapa>();
            //mapa.finNivel();


            //Salir de la escena a victoria
            SceneManager.LoadScene("Victory");

        }
    }
}
