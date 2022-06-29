/******************************************************************************
* �� �� �� : 2022-06-21
* ��    �� : ������Ʈ�� ���� ���⸦ �����Ѵ�
* �� �� �� :
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

        // �Ÿ�
        if (Vector3.Distance(attacker.transform.position, defender.transform.position) > attackRange)
        {
            return;
        }

        // ����
        var dir = defender.transform.position - attacker.transform.position;
        dir.Normalize();
        var dot = Vector3.Dot(attacker.transform.forward, dir); // ��������
        if (dot < 0.5f)
        {
            return;
        }

        // ����
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
