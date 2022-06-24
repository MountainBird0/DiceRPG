/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 공격당했을 때 사용할 인터페이스
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    void OnAttack(GameObject attacker, Attack attack);
}
