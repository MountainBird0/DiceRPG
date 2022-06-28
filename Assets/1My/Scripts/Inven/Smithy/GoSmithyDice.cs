using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSmithyDice : MonoBehaviour
{
    private Slot slot;
    private Dice curDice;

    private void Awake()
    {
        slot = GetComponent<Slot>();
    }

    public void Click()
    {
        Debug.Log("[GoSmithyDice] 클릭함");
        curDice = slot.dice;

        if (!slot.IsSlot())
        {
            Debug.Log("[GoSmithyDice] 비어있음");
            return;
        }
        slot.Dice = null;
        int i = SmithyManager.instance.NearSlot(Input.mousePosition);
        SmithyManager.instance.AddAnvilSlot(curDice, i);

    }

}
