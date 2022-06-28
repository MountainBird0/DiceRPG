/******************************************************************************
* 작 성 일 : 2022-06-23
* 내    용 : 직선형 범위 스킬의 토대
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartPlayerSkill.asset", menuName = "Skill / StartPlayer")]
public class StartPlayerSkill : AttackDefinition
{
    public GameObject effectPrefab;
    public float effectDuration;

    public Vector3 range= new Vector3(1,1,1);
    public Quaternion dir;

    public Vector3 startPoint;

    private RaycastHit[] targets = new RaycastHit[0];

    public void Fire(GameObject caster, Vector3 position, int layerMask)
    {
        Debug.Log("[StartPlayerSkill] 실제 스킬 함수");
        if (caster == null)
            return;

        dir = caster.transform.rotation;
        var go = Instantiate(effectPrefab, position, dir);
        Destroy(go, effectDuration);

        //var go = ObjectPoolManager.instance.GetObject("CleaveGeneric");
        //go.transform.position = position;
        //go.transform.rotation = rot;
        //StartCoroutine(Delay(go));


        startPoint = go.transform.position;
        var cols = Physics.OverlapBox(startPoint, range);
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

        startPoint.z = go.transform.position.x + 2;
        cols = Physics.OverlapBox(startPoint, range);
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

        //lineRenderer.SetPosition(0, transform.position);
        //targets = Physics.BoxCastAll(caster.transform.position, range, caster.transform.forward, dir,
        //    100, layerMask);
        //Debug.Log($"[StartPlayerSkill] {targets.Length}");

        //foreach (var target in targets)
        //{
        //    Debug.Log($"[StartPlayerSkill] {targets.Length}");
        //}

        //if (true == Physics.BoxCastAll(caster.transform.position, range, caster.transform.forward, dir, 
        //    3, layerMask))
        //{
        //    lineRenderer.SetPosition(1, hitInfo.point);
        //    var enemy = hitInfo.collider.GetComponent<EnemyHealth>();

        //    enemy?.TakeDamage(damage, hitInfo.point);
        //}
        //else
        //{
        //    lineRenderer.SetPosition(1, transform.position + transform.forward * range);
        //}









    }
}
