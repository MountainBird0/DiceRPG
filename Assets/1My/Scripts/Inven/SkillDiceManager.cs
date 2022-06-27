/******************************************************************************
* 작 성 일 : 2022-06-27
* 내    용 : 전투화면 주사위를 관리함
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDiceManager : MonoBehaviour
{
    [SerializeField] private Transform skillDiceParent1;
    [SerializeField] private Transform skillDiceParent2;
    [SerializeField] private Transform skillDiceParent3;

    [SerializeField] private Slot skillDice1;
    [SerializeField] private Slot skillDice2;
    [SerializeField] private Slot skillDice3;

    private void OnValidate()
    {
        skillDice1 = skillDiceParent1.GetComponentInChildren<Slot>();
        //skillDice2 = skillDiceParent2.GetComponentInChildren<Slot>();
        //skillDice3 = skillDiceParent3.GetComponentInChildren<Slot>();
    }

    public void Start()
    {
        GetRanDice();
    }

    public void GetRanDice()
    {
        int num = Random.Range(0, 6);
        skillDice1.Dice = InventoryManager.instance.intactDice1[num];
        //skillDice2.Dice = InventoryManager.instance.intactDice2[num];
        //skillDice3.Dice = InventoryManager.instance.intactDice3[num];
    }

    public void RemoveDice()
    {
        skillDice1.Dice = null;
    }

}
