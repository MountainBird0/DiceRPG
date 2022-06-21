using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private string ObjectName;
    private List<GameObject> spawnPoints = new List<GameObject>();

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
            prefab.transform.position =spawnPoints[i].transform.position;
         

            Debug.Log($"[SpawnManager] : {spawnPoints[i].transform.position}소환");
        }
    }
}
