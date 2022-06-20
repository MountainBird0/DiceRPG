/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 게임에서 사용할 오브젝트들을 미리 저장해둠
* 수 정 일 :
*******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolData
{
    public GameObject prefab;
    public int count;
    public List<GameObject> list;
}

public class ObjectPoolManager : MonoBehaviour
{

    public static ObjectPoolManager instance;

    public List<PoolData> poolData = new List<PoolData>();

    /**********************************************************
     * 설명 : 게임 시작과 동시에 싱글톤을 구성
     ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 ObjectPool이 존재합니다!");
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
        AddObjectToPool();
    }

    /**********************************************************
     * 설명 : 오브젝트들을 Pool에 추가함
     ***********************************************************/
    private void AddObjectToPool()
    {
        foreach (var pool in poolData)
        {
            for (int i = 0; i < pool.count; i++)
            {
                var Object = Instantiate(pool.prefab, transform);
                pool.list.Add(Object);
                Object.transform.localPosition = Vector3.zero;
                Object.SetActive(false);
            }
        }
    }

    /**********************************************************
    * 설명 : 외부에서 오브젝트를 가지고 감
     ***********************************************************/
    public GameObject GetObject(string prefabName)
    {
        foreach (var pool in poolData)
        {
            if(pool.prefab.name.Equals(prefabName))
            {
                if(pool.list != null)
                {
                    foreach(var item in pool.list)
                    {
                        if(!item.activeSelf)
                        {
                            item.SetActive(true);
                            return item;
                        }
                        //var Object = Instantiate(pool.prefab, transform);
                        //pool.list.Add(Object);
                        //Object.transform.localPosition = Vector3.zero;
                        //Object.SetActive(false);

                        //return Object;
                    }
                }
            }
        }
        return null;
    }

}
