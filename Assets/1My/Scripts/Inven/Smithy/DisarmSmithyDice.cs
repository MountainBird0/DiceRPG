using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmSmithyDice : MonoBehaviour
{
    private Slot slot;
    private Dice curDice;

    private void Awake()
    {
        slot = GetComponent<Slot>();
    }

    public void Click()
    {
        Debug.Log("[GoSmithyDice] Ŭ����");
        curDice = slot.dice;

        if (!slot.IsSlot())
        {
            Debug.Log("[GoSmithyDice] �������");
            return;
        }
        SmithyManager.instance.RemoveAnvilSlot(curDice);
    }
}
