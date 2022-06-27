/******************************************************************************
* �� �� �� : 2022-06-27
* ��    �� : ��ü���� �κ��丮�� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dice startDice;

    public List<Dice> intactDice1;
    public List<Dice> intactDice2;
    public List<Dice> intactDice3;
    public List<Dice> dices;

    [SerializeField] private Transform diceSlotParent1;
    [SerializeField] private Transform diceSlotParent2;
    [SerializeField] private Transform diceSlotParent3;
    [SerializeField] private Transform bagSlotsParent;

    [SerializeField] private Slot[] diceSlot1;
    [SerializeField] private Slot[] diceSlot2;
    [SerializeField] private Slot[] diceSlot3;
    [SerializeField] private Slot[] bagslots;

    public static InventoryManager instance;

    private void OnValidate()
    {
        diceSlot1 = diceSlotParent1.GetComponentsInChildren<Slot>();
        diceSlot2 = diceSlotParent2.GetComponentsInChildren<Slot>();
        diceSlot3 = diceSlotParent3.GetComponentsInChildren<Slot>();
        bagslots = bagSlotsParent.GetComponentsInChildren<Slot>();
    }

    /**********************************************************
    * ���� : ���ο� ���� ���۽� �κ��丮�� ����
    ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� InventoryManager �����մϴ�!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("[InventoryManager] ����Ǵ�?");
        for (int i = 0; i < diceSlot1.Length; i++)
        {
            intactDice1.Add(startDice);
            intactDice2.Add(startDice);
            intactDice3.Add(startDice);
        }
        FreshIntactSlot(1);
        FreshIntactSlot(2);
        FreshIntactSlot(3);
        FreshSlot();
    }

    /**********************************************************
    * ���� :�κ��丮 ���� ����
    ***********************************************************/
    public void FreshSlot()
    {
        int i = 0;
        for (; i < dices.Count && i < bagslots.Length; i++)
        {
            bagslots[i].Dice = dices[i];
        }
        for (; i < bagslots.Length; i++)
        {
            bagslots[i].Dice = null;
        }
    }

    /**********************************************************
    * ���� : �ֻ����� ���濡 ����
    ***********************************************************/
    public void GetDice(Dice dice)
    {
        if (dices.Count < bagslots.Length)
        {
            dices.Add(dice);
            FreshSlot();
        }
        else
        {
            Debug.Log("������ �� ��");
        }
    }

    /**********************************************************
    * ���� : ������ �ֻ����� ����  
    ***********************************************************/
    public void RemoveDice(int index)
    {
        Debug.Log($"[InventoryManager].HideDice() index? {index}");
        dices.RemoveAt(index);
        FreshSlot();
    }

    public void RemoveDice(int slotNum, int index)
    {
        if(slotNum == 1)
        {
            intactDice1.RemoveAt(index);
            Debug.Log($"[InventoryManager].�ʱ�ȭ");
            FreshIntactSlot(slotNum);
        }
        if (slotNum == 2)
        {
            intactDice2.RemoveAt(index);
            FreshIntactSlot(slotNum);
        }
        if (slotNum == 3)
        {
            intactDice3.RemoveAt(index);
            FreshIntactSlot(slotNum);
        }
    }

    /**********************************************************
    * ���� : ���̽��� ����
    ***********************************************************/
    public void DropDice(int index, Dice dice)
    {
        dices.Insert(index, dice);
        //dices.Add(dice);
        FreshSlot();
    }

    /**********************************************************
    * ���� : ���콺�� ����� ������ ��ȯ
    ***********************************************************/
    public int[] NearSlot(Vector3 pos)
    {
        float min = 10000f;
        int slotNum = -1;
        int index = -1;

        for (int i = 0; i < bagslots.Length; i++)
        {
            Vector2 sPos = bagslots[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);
            
            if (dis < min)
            {
                min = dis;
                slotNum = 4;
                index = i;             
            }
        }

        for (int i = 0; i < diceSlot1.Length; i++)
        {
            Vector2 sPos = diceSlot1[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);

            if (dis < min)
            {
                min = dis;
                slotNum = 1;
                index = i;
            }
        }

        for (int i = 0; i < diceSlot2.Length; i++)
        {
            Vector2 sPos = diceSlot2[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);

            if (dis < min)
            {
                min = dis;
                slotNum = 2;
                index = i;
            }
        }

        for (int i = 0; i < diceSlot3.Length; i++)
        {
            Vector2 sPos = diceSlot3[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);

            if (dis < min)
            {
                min = dis;
                slotNum = 3;
                index = i;
            }
        }

        //if (min > dices.Count)
        //{
        //    return godata;
        //}

        Debug.Log($"[InventoryManager]. ���Գѹ�:{slotNum}, �ε���:{index}");
        int[] godata = { slotNum, index };
        return godata;
    }

    //////////////
    /// �ֻ��� 1 �ϼ�
    /////////////

    /**********************************************************
    * ���� : ���â�� �ֻ����� ����
    ***********************************************************/
    public void AddIntactDice(Dice dice, int slotNum)
    {
        if (slotNum == 1)
        { 
            if(intactDice1.Count < diceSlot1.Length)
            {
                intactDice1.Add(dice);
                FreshIntactSlot(slotNum);
            }
            else
            {
                Debug.Log("���â�� �� ��");
            }
        }

        if (slotNum == 2)
        {
            if (intactDice2.Count < diceSlot2.Length)
            {
                intactDice2.Add(dice);
                FreshIntactSlot(slotNum);
            }
            else
            {
                Debug.Log("���â�� �� ��");
            }
        }

        if (slotNum == 3)
        {
            if (intactDice3.Count < diceSlot3.Length)
            {
                intactDice3.Add(dice);
                FreshIntactSlot(slotNum);
            }
            else
            {
                Debug.Log("���â�� �� ��");
            }
        }

        if(slotNum == 4)
        {
            if (dices.Count < bagslots.Length)
            {
                dices.Add(dice);
                FreshSlot();
            }
            else
            {
                Debug.Log("������ �� ��");
            }
        }
    }

    /**********************************************************
    * ���� : ���â ����
    ***********************************************************/
    public void FreshIntactSlot(int slotNum)
    {
        if(slotNum == 1)
        {
            int i = 0;
            for(; i < intactDice1.Count && i < diceSlot1.Length; i++)
            {
                diceSlot1[i].Dice = intactDice1[i];
            }
            for(; i < diceSlot1.Length; i++)
            {
                diceSlot1[i].Dice = null;
            }
        }
        if (slotNum == 2)
        {
            int i = 0;
            for (; i <intactDice2.Count && i < diceSlot2.Length; i++)
            {
                diceSlot2[i].Dice = intactDice2[i];
            }
            for (; i < diceSlot2.Length; i++)
            {
                diceSlot2[i].Dice = null;
            }
        }
        if (slotNum == 3)
        {
            int i = 0;
            for (; i <intactDice3.Count && i < diceSlot3.Length; i++)
            {
                diceSlot3[i].Dice = intactDice3[i];
            }
            for (; i < diceSlot3.Length; i++)
            {
                diceSlot3[i].Dice = null;
            }
        }
    }
}


/**********************************************************
    * ���� : �������� ����
    ***********************************************************/
//public void Swap(Slot slot, Vector3 pos)
//{
//    //Debug.Log($"[InventoryManager] ���� �Լ� ���ۺκ�");
//    //Slot firstSlot = NearSlot(pos);
//    //Debug.Log($"[InventoryManager] ���۽���? : {firstSlot}");


//    //if (slot == firstSlot || firstSlot == null)
//    //{
//    //    return;
//    //}

//    //if (!firstSlot.IsSlot())
//    //{
//    //    Debug.Log($"[InventoryManager] ���� �Լ� ����");
//    //    Swap(firstSlot, slot);
//    //}
//    //else
//    //{
//    //    Swap(slot, firstSlot);
//    //}
//}

//private void Swap(Slot first, Slot second)
//{
//    Slot temp = null;
//    temp.image = first.image;
//    first.image = second.image;
//    second.image = first.image;
//}

/**********************************************************
   * ���� : �� �κ��� �������� ����
   ***********************************************************/
////public void OutDice(int index)
////{
////    dices.RemoveAt(index);
////    FreshSlot();
//}

/**********************************************************
    * ���� : �������� ���ϴ� ��ġ�� ���
    ***********************************************************/
//public void Drop(Dice dice, Vector3 pos)
//{
//    //int startSlot = NearSlot(Input.mousePosition);
//    //Debug.Log($"[InventoryManager] startSlot����? {startSlot}");
//    //int i = startSlot;
//    //Debug.Log($"[InventoryManager] i����? {i}");
//    //dices.Insert(i, dice);
//    //Debug.Log($"[InventoryManager] dice����? {dice}");

//    //bagslots[i].Dice = dice;

//    //for (; i < dices.Count && i < bagslots.Length; i++)
//    //{
//    //    bagslots[i+1].Dice = dices[i];
//    //}
//    //i += 1;
//    //for (; i < bagslots.Length; i++)
//    //{
//    //    bagslots[i].Dice = null;
//    //}
//    //FreshSlot();
//}

//public void FreshSlot()
//{
//    int i = 0;
//    for (; i < dices.Count && i < bagslots.Length; i++)
//    {
//        bagslots[i].Dice = dices[i];
//    }
//    for (; i < bagslots.Length; i++)
//    {
//        bagslots[i].Dice = null;
//    }
//}

//public void TransForward(int index)
//{
//    for (int i = index; i < dices.Count; i++)
//    {
//        bagslots[i+1].transform.SetSiblingIndex(i);
//        //bagslots[i+1].transform.SetAsLastSibling();
//    }
//    FreshSlot();

//    //bagslots[1].transform.SetSiblingIndex(2);
//}