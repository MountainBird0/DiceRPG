/******************************************************************************
* �� �� �� : 2022-06-21
* ��    �� : �÷��̾��� ��Ʈ���� ���
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScrolling : MonoBehaviour, IAttackable
{
    public GameObject text;
    public Transform getpos;

    public Color color;

    public float offsetY = 5f;

    public void OnAttack(GameObject attacker, Attack attack)
    {
        text.GetComponent<Scroll>().damage = attack.Damage;


        var s = transform.position;
        var pos = getpos.position;
        //pos.y += offsetY;

        pos.y += offsetY;
        text.transform.position = pos;
        var go = Instantiate(text);

        // prefab.Init(attack.Damage.ToString(), Color.red);
        // text.transform.position = attacker.transform.position;
    }

}
