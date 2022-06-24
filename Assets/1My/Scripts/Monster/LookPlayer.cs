/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : Ÿ���� ���� �÷��̾ �ٶ󺸵��� ��
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    private GameObject target;

    private void Awake()
    {
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            this.transform.LookAt(target.transform.position);
        }
    }
}
