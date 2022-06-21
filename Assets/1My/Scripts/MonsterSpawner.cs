/******************************************************************************
* �� �� �� : 2022-06-20
* ��    �� : ��Ʋ�ʵ忡 �������� �� ���͸� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SlowSpawn());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnManager.instance.Spawning();
        }
    }

    IEnumerator SlowSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log($"[MonsterSpawner] : ��ȯ ����");
        SpawnManager.instance.Spawning();
    }
}
