/******************************************************************************
* 작 성 일 : 2022-06-18
* 내    용 : 카메라가 플레이어를 따라다니도록 함
* 수 정 일 :
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
    * 설명 : 카메라가 플레이어를 따라다니도록 함
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
