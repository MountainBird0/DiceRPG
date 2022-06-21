/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ���ӿ��� ����� ������Ʈ���� �̸� �����ص�
* �� �� �� :
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
     * ���� : ���� ���۰� ���ÿ� �̱����� ����
     ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� ObjectPool�� �����մϴ�!");
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
        AddObjectToPool();
    }

    /**********************************************************
     * ���� : ������Ʈ���� Pool�� �߰���
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
    * ���� : �ܺο��� ������Ʈ�� ������ ��
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
