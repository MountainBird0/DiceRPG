/******************************************************************************
* �� �� �� : 2022-06-21
* ��    �� : �⺻ ���ݿ� �ʿ��� ��� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack.asset", menuName = "Attack/BasicAttack")]
public class AttackDefinition : ScriptableObject
{
    public float coolDown;
    public float attackRange;
    public float minDamage;
    public float maxDamage;

    public Attack CreateAttack(LivingEntity attacker, LivingEntity defender)
    {
        float damage = attacker.damage;
        damage += Random.Range(minDamage, maxDamage);

        return new Attack((int)damage);
    }
}
