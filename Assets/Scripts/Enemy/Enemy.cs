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
            m_Animator.SetBool("Attack",true);
            m_Animator.SetBool("Run", false);
            ataccking = true;
            player.transform.position = new Vector3(-5, 0, 0);
            player.GetComponent<PlayerMovement>().speed = 5.0f;
            StartCoroutine(ExampleCoroutine());
        }
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
            statsplayer.removevida(20);
        }
    }
  
    void Update()
    {
       dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist <5f)
        {
            if (ataccking == false) { 
            agent.SetDestination(player.transform.position);
            m_Animator.SetBool("Run",true);
            }
        }
        else
        {
            agent.SetDestination(this.transform.position);
            m_Animator.SetBool("Run", false);
        }
    }
}
