/******************************************************************************
* 작 성 일 : 2022-06-23
* 내    용 : 피격 데미지 텍스트 표현
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScrolling : MonoBehaviour, IAttackable
{
    public GameObject text;
    public Transform getpos;

    public Color color;

    public float offsetY = 1f;

    public void OnAttack(GameObject attacker, Attack attack)
    {
        text.GetComponent<Scroll>().damage = attack.Damage;


        var s = transform.position;
        var pos = getpos.position;

        pos.y += offsetY;
        text.transform.position = pos;
        var go = Instantiate(text);

        //text.GetComponent<Scroll>().Init(color);
        //text.transform.position = attacker.transform.position;
    }

}
