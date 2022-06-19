using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private string ObjectName;
    private List<GameObject> spawnPoints = new List<GameObject>();

    /**********************************************************
    * ���� : ���� ���۰� ���ÿ� �̱����� ����
    ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� SpawnManager�� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    /**********************************************************
    * ���� : ������ ������Ʈ�� ����
    ***********************************************************/
    public void GetNameOfPrefab(string name)
    {
        ObjectName = name;
        Debug.Log($"[SpawnManager] : ��ȯ�� ������Ʈ : {ObjectName}");
    }


    /**********************************************************
    * ���� : ������Ʈ�� ������
    ***********************************************************/
    public void Spawning()
    {
        spawnPoints.Clear();

        foreach (var point in GameObject.FindGameObjectsWithTag("SpawnPointMonster"))
        {
            spawnPoints.Add(point);
        }

        if(spawnPoints.Count == 0)
        {
            Debug.Log($"[SpawnManager] : ��������Ʈ����");

        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var prefab = ObjectPoolManager.instance.GetObject(ObjectName);
            prefab.transform.position =spawnPoints[i].gameObject.transform.position;
            Debug.Log($"[SpawnManager] : {spawnPoints[i].gameObject.transform.position}��ȯ");
        }
    }


    void Start()
    {

    }


    void Update()
    {



    }
}
