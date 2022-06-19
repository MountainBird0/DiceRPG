/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 적이 플레이어 쪽으로 이동하도록 함
* 수 정 일 :
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
