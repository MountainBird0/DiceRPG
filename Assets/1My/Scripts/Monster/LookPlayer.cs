/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 타운의 적이 플레이어를 바라봄
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
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.transform.LookAt(target.transform.position);
    }
}
