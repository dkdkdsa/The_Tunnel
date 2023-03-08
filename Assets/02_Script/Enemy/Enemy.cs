using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform target;
    private PlayerSit sit;
    private PlayerMove playerMove;
    private Vector3 lastPos;
    private Vector3 randomPos;

    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerMove>().transform;
        sit = FindObjectOfType<PlayerSit>();
        playerMove = FindObjectOfType<PlayerMove>();

    }

    private void FixedUpdate()
    {

        if (sit.isSit == false && playerMove.isMove == true)
        {

            Chase();

        }
        else if (playerMove.isMove == false || sit.isSit)
        {

            Idle();

        }

    }

    private void Chase()
    {

        agent.SetDestination(target.position);
        agent.speed = 5f;
        lastPos = target.position;

    }

    private void Idle()
    {

        if (agent.velocity != Vector3.zero) return;

        agent.speed = 2f;

        int n = Random.Range(0, 3);

        if(n == 0)
        {

            randomPos = target.position + new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));


        }
        else
        {

            randomPos = transform.position + new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));

        }

        agent.SetDestination(randomPos);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene("Ending");

        }

    }

}
