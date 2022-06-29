/******************************************************************************
* �� �� �� : 2022-06-23
* ��    �� : ��ų ������ ���� �⺻ ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttackSkill.asset", menuName = "Skill/BasicAttack")]
public class BasicAttackSkill : AttackDefinition
{
    public GameObject effectPrefab;
    public float effectDuration;

    public Vector3 range = new Vector3(1, 1, 1);
    public Quaternion dir;

    public Vector3 startPoint;

    public void Fire(GameObject caster, Vector3 position, int layerMask)
    {
        Debug.Log("[StartPlayerSkill] ���� ��ų �Լ�");
        if (caster == null)
            return;

        dir = caster.transform.rotation;

        var go = Instantiate(effectPrefab, position, dir);
        Destroy(go, effectDuration);

        startPoint += caster.transform.forward * 2;
        var cols = Physics.OverlapBox(startPoint, range);
        foreach (var col in cols)
        {
            if (col.gameObject == caster)
                continue;

            var attackables = col.GetComponentsInChildren<LivingEntity>();
            if (attackables.Length == 0)
                continue;

            var aStates = caster.GetComponent<LivingEntity>();

            var attack = CreateAttack(aStates);
            foreach (var attackable in attackables)
            {
                attackable.OnAttack(caster, attack);
            }
        }      
    }
}
