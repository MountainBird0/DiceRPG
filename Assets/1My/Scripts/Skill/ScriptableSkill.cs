/******************************************************************************
* 작 성 일 : 2022-06-23
* 내    용 : 스킬 구현을 위한 기본 뼈대
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "skill.asset", menuName = "Attack/Skill")]
public class ScriptableSkill : ScriptableObject
{
    public float cooldown; // 쿨타임
    public float range;    // 사정거리
    public float radius;   // 공격범위
    public float minDamage;
    public float maxDamage;
    public GameObject effectPrefab;
    // public float criticalChance;
    // public float criticalMultiplier;


}
