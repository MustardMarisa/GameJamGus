using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    Animator m_Animator;
    Stats statsplayer;
    float dist;
    private bool ataccking = false;

    [Header("Sonidos Enemigo")]
    [SerializeField] private AudioSource enemyAudioSource = default;
    [SerializeField] private AudioClip[] clips = default;
    private float runSoundTimer = 0;
    private float attackTimer = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        statsplayer = Stats.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ataccking = true;
            enemyAttack();
        }
    }

    private void enemyAttack()
    {
        m_Animator.SetBool("Attack", true);
        //enemyAudioSource.PlayOneShot(clips[0]);
        statsplayer.removevida(20);
        m_Animator.SetBool("Run", false);
        player.transform.position = new Vector3(-5, 0, 0);
        player.GetComponent<PlayerMovement>().speed = 5.0f;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(4);
        player.GetComponent<PlayerMovement>().speed = 3.0f;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Animator.SetBool("Attack", false);
            m_Animator.SetBool("Run", true);
            ataccking = false;
        }
    }
  
    void Update()
    {
        if (ataccking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                enemyAttack();
                attackTimer = 1.2f;
            }

        }

       dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist <5f)
        {
            if (ataccking == false) { 
                agent.SetDestination(player.transform.position);
                m_Animator.SetBool("Run",true);

                /*runSoundTimer -= Time.deltaTime;
                if (runSoundTimer <= 0)
                {
                    enemyAudioSource.PlayOneShot(clips[1]);
                    runSoundTimer = clips[1].length;
                }*/
                
            }
        }
        else
        {
            agent.SetDestination(this.transform.position);
            m_Animator.SetBool("Run", false);
        }
    }
}
