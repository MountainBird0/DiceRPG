/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ���� �÷��̾� ������ �̵��ϵ��� ��
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

    }
}
