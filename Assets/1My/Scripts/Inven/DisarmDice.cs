using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmDice : MonoBehaviour
{
    private Slot slot;
    private Dice curDice;


    int[] i;

    private void Awake()
    {
        slot = GetComponent<Slot>();
    }

    public void Disarm()
    {
        Debug.Log("[DisarmDice] 함수실행");
        curDice = slot.dice;

        if (!slot.IsSlot())
        {
            return;
        }

        i = InventoryManager.instance.NearSlot(Input.mousePosition);

        if (i[0] == 4)
        {
            return;
        }
        else
        {
            InventoryManager.instance.RemoveDice(i[0], i[1]);
            InventoryManager.instance.AddDice(curDice);
        }


    }

    //public 
}
