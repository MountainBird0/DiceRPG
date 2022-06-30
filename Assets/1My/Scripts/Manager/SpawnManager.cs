/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 배틀신 진입시 소환할 몬스터 관리
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private string ObjectName;
    private List<GameObject> spawnPoints = new List<GameObject>();

    private int spawnCount = 0;

    /**********************************************************
    * 설명 : 게임 시작과 동시에 싱글톤을 구성
    ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // instance가 비어있다면(null) 그곳에 자기 자신을 할당
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 SpawnManager가 존재합니다!");
            Destroy(gameObject);
        }
    }

    /**********************************************************
    * 설명 : 스폰할 오브젝트를 정함
    ***********************************************************/
    public void GetNameOfPrefab(string name)
    {
        ObjectName = name;
        Debug.Log($"[SpawnManager] : 소환할 오브젝트 : {ObjectName}");
    }


    /**********************************************************
    * 설명 : 오브젝트를 스폰함
    ***********************************************************/
    public void Spawning()
    {
        Debug.Log($"[SpawnManager] : 소환시작");
        spawnPoints.Clear();

        foreach (var point in GameObject.FindGameObjectsWithTag("SpawnPointMonster"))
        {
            Debug.Log($"[SpawnManager] : 스폰포인트 잡음");

            spawnPoints.Add(point);
        }

        if(spawnPoints.Count == 0)
        {
            Debug.Log($"[SpawnManager] : 스폰포인트없음");

        }

        Debug.Log($"[SpawnManager] : 소환할건{ObjectName}");

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var prefab = ObjectPoolManager.instance.GetObject(ObjectName);
            prefab.transform.position = spawnPoints[i].transform.position;
            spawnCount++;

            Debug.Log($"[SpawnManager] : {spawnPoints[i].transform.position}소환");
        }
    }

    /**********************************************************
    * 설명 : 보스몬스터 타운에 스폰함
    ***********************************************************/
    public void BossSpawning()
    {
        //var spawnPoint = GameObject.FindGameObjectWithTag("BossZone");
        Vector3 spawnPoint = new Vector3(-9.6f, 2.14f, -22.11f);
        Debug.Log($"[SpawnManager]포인트위치{ spawnPoint}");
        var boss = ObjectPoolManager.instance.GetObject("Wraith_Boss");
        boss.transform.position = spawnPoint;
        Debug.Log($"[SpawnManager]보스위치{boss.transform.position}");



    }

}
