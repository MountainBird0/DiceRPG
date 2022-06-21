/******************************************************************************
* 작 성 일 : 2022-06-20
* 내    용 : 배틀필드에 진입했을 때 몬스터를 스폰
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"[MonsterSpawner] : 소환 시작");
        SpawnManager.instance.Spawning();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnManager.instance.Spawning();
        }
    }
}
