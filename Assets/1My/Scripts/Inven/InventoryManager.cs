using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
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

    private void Update()
    {

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
    * ���� : �������� ���濡 ����
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
    * ���� : �� �κ��� �������� ����
    ***********************************************************/
    public void OutDice(int index)
    {
        dices.RemoveAt(index);
        FreshSlot();
    }

    /**********************************************************
    * ���� : ���콺�� ����� ������ ��ȯ
    ***********************************************************/
    public int NearSlot(Vector3 pos)
    {
        float min = 10000;
        int index = -1;

        int count = dices.Count;
        for (int i = 0; i < count; i++)
        {
            Vector2 sPos = bagslots[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);

            if (dis < min)
            {
                min = dis;
                index = i;
            }
        }

        if (min > dices.Count)
        {
            return 0;
        }
        return index;
    }

    /**********************************************************
    * ���� : �������� ���ϴ� ��ġ�� ���
    ***********************************************************/
    public void Drop(Dice dice, Vector3 pos)
    {
        int startSlot = NearSlot(Input.mousePosition);
        Debug.Log($"[InventoryManager] startSlot����? {startSlot}");
        int i = startSlot;
        Debug.Log($"[InventoryManager] i����? {i}");
        dices.Insert(i, dice);
        //bagslots[i].Dice = slot.Dice;

        for (; i < dices.Count && i < bagslots.Length; i++)
        {
            bagslots[i+1].Dice = dices[i];
        }
        i += 1;
        for (; i < bagslots.Length; i++)
        {
            bagslots[i].Dice = null;
        }
    }

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


    /**********************************************************
    * ���� : �������� ����
    ***********************************************************/
    public void Swap(Slot slot, Vector3 pos)
    {
        //Debug.Log($"[InventoryManager] ���� �Լ� ���ۺκ�");
        //Slot firstSlot = NearSlot(pos);
        //Debug.Log($"[InventoryManager] ���۽���? : {firstSlot}");


        //if (slot == firstSlot || firstSlot == null)
        //{
        //    return;
        //}

        //if (!firstSlot.IsSlot())
        //{
        //    Debug.Log($"[InventoryManager] ���� �Լ� ����");
        //    Swap(firstSlot, slot);
        //}
        //else
        //{
        //    Swap(slot, firstSlot);
        //}
    }

    private void Swap(Slot first, Slot second)
    {
        Slot temp = null;
        temp.image = first.image;
        first.image = second.image;
        second.image = first.image;
    }

}
