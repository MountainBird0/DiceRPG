/******************************************************************************
* �� �� �� : 2022-06-20
* ��    �� : ���� ���� �� ����, ȸ�����, ��ȭ��Ҹ� �����ϰ� ����
* �� �� �� :
*******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZone : MonoBehaviour
{
    private List<GameObject> emptyZones = new List<GameObject>();
    private string[] monsters = { "Spore", "Chewer" };

    private int monsterZone;
    private int powerUpZone;
    private int healingZone;
    private int sumZone;

    private int selectPosition;

    private void Awake()
    {
        emptyZones.Clear();

        foreach (var zone in GameObject.FindGameObjectsWithTag("EmptyZone"))
        {
            emptyZones.Add(zone);
        }
        DistributionZone();
    }

    private void Start()
    {
        if(!GameManager.instance.IsBossAlive())
        {
            SpawnObject();
            GameManager.instance.SetBossAlive(true);
        }
    }

    /**********************************************************
     * ���� : zone�� ������ �°� ���
     ***********************************************************/
    private void DistributionZone()
    {
        monsterZone = (int)(emptyZones.Count * 0.7f); // Healing_Space_T
        powerUpZone = (int)(emptyZones.Count * 0.2f);
        healingZone = (int)Math.Ceiling(emptyZones.Count * 0.1f);

        Debug.Log($"{emptyZones.Count}, {monsterZone}, {powerUpZone}, {healingZone}");

        sumZone = monsterZone + powerUpZone + healingZone;
    }

    /**********************************************************
    * ���� : ���� ���͸� ��
    ***********************************************************/
    private int SelectMonster()
    {
        int num = UnityEngine.Random.Range(0, 2);
        return num;
    }

    /**********************************************************
    * ���� : �� ���� ������Ʈ ����
    ***********************************************************/
    private void SpawnObject()
    {
        for (int i = 0; i < monsterZone; i++)
        {
            Debug.Log("���� ��");
            var prefab = ObjectPoolManager.instance.GetObject(monsters[SelectMonster()].ToString());
            selectPosition = UnityEngine.Random.Range(0, emptyZones.Count);
            prefab.transform.position = emptyZones[selectPosition].transform.position;
            emptyZones[selectPosition].gameObject.SetActive(false);
            emptyZones.RemoveAt(selectPosition);
        }

        for (int i = 0; i < powerUpZone; i++)
        {
            Debug.Log("�Ŀ� ��");
            var prefab = ObjectPoolManager.instance.GetObject("Power_Space_T");
            selectPosition = UnityEngine.Random.Range(0, emptyZones.Count);
            prefab.transform.position = emptyZones[selectPosition].transform.position;
            emptyZones[selectPosition].gameObject.SetActive(false);
            emptyZones.RemoveAt(selectPosition);
        }

        for (int i = 0; i < healingZone; i++)
        {
            Debug.Log("���� ��");
            var prefab = ObjectPoolManager.instance.GetObject("Healing_Space_T");
            selectPosition = UnityEngine.Random.Range(0, emptyZones.Count);
            prefab.transform.position = emptyZones[selectPosition].transform.position;
            emptyZones[selectPosition].gameObject.SetActive(false);
            emptyZones.RemoveAt(selectPosition);
        }
    }
}
