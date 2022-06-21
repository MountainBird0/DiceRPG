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
        Debug.Log($"[SpawnManager] : ��ȯ����");
        spawnPoints.Clear();

        foreach (var point in GameObject.FindGameObjectsWithTag("SpawnPointMonster"))
        {
            Debug.Log($"[SpawnManager] : ��������Ʈ ����");

            spawnPoints.Add(point);
        }

        if(spawnPoints.Count == 0)
        {
            Debug.Log($"[SpawnManager] : ��������Ʈ����");

        }

        Debug.Log($"[SpawnManager] : ��ȯ�Ұ�{ObjectName}");

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var prefab = ObjectPoolManager.instance.GetObject(ObjectName);
            prefab.transform.position =spawnPoints[i].transform.position;
         

            Debug.Log($"[SpawnManager] : {spawnPoints[i].transform.position}��ȯ");
        }
    }
}
