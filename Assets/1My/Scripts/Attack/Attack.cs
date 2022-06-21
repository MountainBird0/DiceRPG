/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public int Damage { get; private set; }

    public Attack(int damage)
    {
        Damage = damage;
    }
}
