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
        Debug.Log($"[MonsterSpawner] : ��ȯ ����");
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
