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
    private GameObject target;
    private NavMeshAgent agent;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDisable()
    {
        agent.enabled = false;
    }

    void Update()
    {
        //target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
        {
            Init();
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

    public void Init()
    {
        if(!agent.enabled)
        {
            agent.enabled = true;
        }
    }
}
