/******************************************************************************
* 작 성 일 : 2022-06-20
* 내    용 : 게임 시작 시 몬스터, 회복장소, 강화장소를 랜덤하게 스폰
* 수 정 일 :
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
     * 설명 : zone을 비율에 맞게 배분
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
    * 설명 : 랜덤 몬스터를 고름
    ***********************************************************/
    private int SelectMonster()
    {
        int num = UnityEngine.Random.Range(0, 2);
        return num;
    }

    /**********************************************************
    * 설명 : 존 위에 오브젝트 스폰
    ***********************************************************/
    private void SpawnObject()
    {
        for (int i = 0; i < monsterZone; i++)
        {
            Debug.Log("몬스터 존");
            var prefab = ObjectPoolManager.instance.GetObject(monsters[SelectMonster()].ToString());
            selectPosition = UnityEngine.Random.Range(0, emptyZones.Count);
            prefab.transform.position = emptyZones[selectPosition].transform.position;
            emptyZones[selectPosition].gameObject.SetActive(false);
            emptyZones.RemoveAt(selectPosition);
        }

        for (int i = 0; i < powerUpZone; i++)
        {
            Debug.Log("파워 존");
            var prefab = ObjectPoolManager.instance.GetObject("Power_Space_T");
            selectPosition = UnityEngine.Random.Range(0, emptyZones.Count);
            prefab.transform.position = emptyZones[selectPosition].transform.position;
            emptyZones[selectPosition].gameObject.SetActive(false);
            emptyZones.RemoveAt(selectPosition);
        }

        for (int i = 0; i < healingZone; i++)
        {
            Debug.Log("힐링 존");
            var prefab = ObjectPoolManager.instance.GetObject("Healing_Space_T");
            selectPosition = UnityEngine.Random.Range(0, emptyZones.Count);
            prefab.transform.position = emptyZones[selectPosition].transform.position;
            emptyZones[selectPosition].gameObject.SetActive(false);
            emptyZones.RemoveAt(selectPosition);
        }
    }
}
