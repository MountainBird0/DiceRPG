/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 타운의 적이 플레이어를 바라보도록 함
* 수 정 일 :
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
