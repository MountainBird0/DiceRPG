/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : Ÿ���� ���� �÷��̾ �ٶ�
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
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.transform.LookAt(target.transform.position);
    }
}
