/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 기본 공격에 필요한 요소 정의
* 수 정 일 :
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
