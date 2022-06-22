using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "skill.asset", menuName = "skill / StartPlayer")]
public class StartPlayerSkill : AttackDefinition
{
    public GameObject effectPrefab;
    public float effectDuration;


    public Vector3 range= new Vector3(1,1,1);
    public Quaternion dir;

    public void Fire(GameObject caster, Vector3 position)
    {
        Debug.Log("[StartPlayerSkill] 실제 스킬 함수");
        if (caster == null)
            return;

        dir = caster.transform.rotation;
        dir.x = 0;
        dir.z = 0;

        var go = Instantiate(effectPrefab, position, effectPrefab.transform.rotation);
        Destroy(go, effectDuration);

        var cols = Physics.OverlapBox(position, range);
        foreach (var col in cols)
        {
            if (col.gameObject == caster)
                continue;

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
