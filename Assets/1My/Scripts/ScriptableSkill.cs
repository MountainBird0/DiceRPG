using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill.asset", menuName = "Attack/Skill")]
public class ScriptableSkill : ScriptableObject
{
    public float cooldown; // ��Ÿ��
    public float range;    // �����Ÿ�
    public float radius;   // ���ݹ���
    public float minDamage;
    public float maxDamage;
    public GameObject effectPrefab;
    // public float criticalChance;
    // public float criticalMultiplier;


}
