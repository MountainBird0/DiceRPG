using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "skill.asset", menuName = "skill / CircleRange")]
public class CircleRangeSkill : AttackDefinition
{
    public float radius;

    public GameObject effectPrefab;
    public float effectDuration;

    public void Fire(GameObject caster, Vector3 position, int layerMask)
    {
        Debug.Log("[CircleRangeSkill] 실제 스킬 함수");
        if (caster == null)
            return;

        var go = Instantiate(effectPrefab, position, effectPrefab.transform.rotation);
        Destroy(go, effectDuration);

        var cols = Physics.OverlapSphere(position, radius);
        foreach (var col in cols)
        {
            if (col.gameObject == caster)
                continue;

            //if (col.gameObject.layer == layerMask)
            //    continue;

            var attackables = col.GetComponentsInChildren<IAttackable>();
            if (attackables.Length == 0)
                continue;
            

            var aStates = caster.GetComponent<LivingEntity>();
            var dStates = caster.GetComponent<LivingEntity>();

            var attack = CreateAttack(aStates, dStates);
            foreach (var attackable in attackables)
            {
                attackable.OnAttack(caster, attack);
            }
        }
    }
}

