/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 오브젝트가 가질 무기를 정의한다
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon.asset", menuName = "Attack/Weapon")]
public class Weapon : AttackDefinition
{
    public GameObject prefab; // ?

    public void ExecuteAttack(GameObject attacker, GameObject defender)
    {
        if (defender == null)
        {
            return;
        }

        // 거리
        if (Vector3.Distance(attacker.transform.position, defender.transform.position) > attackRange)
        {
            return;
        }

        // 방향
        var dir = defender.transform.position - attacker.transform.position;
        dir.Normalize();
        var dot = Vector3.Dot(attacker.transform.forward, dir); // 내적연산
        if (dot < 0.5f)
        {
            return;
        }

        // 공격
        var aStates = attacker.GetComponent<LivingEntity>();
        var dStates = defender.GetComponent<LivingEntity>();
        var attack = CreateAttack(aStates);

        var attackables = defender.GetComponentsInChildren<IAttackable>();
        Debug.Log(attackables.Length);
        foreach (var attackable in attackables)
        {
            attackable.OnAttack(attacker, attack);
        }

    }


}
