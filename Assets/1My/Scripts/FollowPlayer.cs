/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ���� �÷��̾� ������ �̵��ϵ��� ��
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
        {
            agent.destination = target.transform.position;

            //if (distance < 1.5)
            //{
            //    agent.speed = 0;
            //    animator.SetBool("IsWalking", false);
            //}
            //else
            //{
            //    agent.speed = speed;
            //    agent.destination = target.transform.position;
            //    animator.SetBool("IsWalking", true);
            //}      
        }

    }
}
