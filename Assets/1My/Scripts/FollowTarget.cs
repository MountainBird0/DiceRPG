/******************************************************************************
* �� �� �� : 2022-06-18
* ��    �� : ī�޶� �÷��̾ ����ٴϵ��� ��
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private GameObject target;
    Vector3 offset;

    bool check;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /**********************************************************
    * ���� : ī�޶� �÷��̾ ����ٴϵ��� ��
    ***********************************************************/
    private void LateUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        else
        {
            if (!check)
            {
                offset = transform.position - target.transform.position;
                check = true;
            }

            transform.position = target.transform.position + offset;

            return;
        }
    }
}
