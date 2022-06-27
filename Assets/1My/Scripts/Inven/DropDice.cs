/******************************************************************************
* 작 성 일 : 2022-06-27
* 내    용 : 드랍된 dice의 정보를 보냄
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDice : MonoBehaviour
{
    public Dice dice;

    public Dice GiveInfo()
    {
        return dice;
    }
}
