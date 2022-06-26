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
    * 설명 : 새로운 게임 시작시 인벤토리를 구성
    ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 InventoryManager 존재합니다!");
            Destroy(gameObject);
        }

    }

    private void Update()
    {

    }


    /**********************************************************
    * 설명 :인벤토리 상태 갱신
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
    * 설명 : 아이템을 가방에 넣음
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
            Debug.Log("가방이 꽉 참");
        }
    }

    /**********************************************************
    * 설명 : 그 부분의 아이템을 제거
    ***********************************************************/
    public void OutDice(int index)
    {
        dices.RemoveAt(index);
        FreshSlot();
    }

    /**********************************************************
    * 설명 : 마우스와 가까운 슬롯을 반환
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
    * 설명 : 아이템을 원하는 위치에 드롭
    ***********************************************************/
    public void Drop(Dice dice, Vector3 pos)
    {
        int startSlot = NearSlot(Input.mousePosition);
        Debug.Log($"[InventoryManager] startSlot값은? {startSlot}");
        int i = startSlot;
        Debug.Log($"[InventoryManager] i값은? {i}");
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
    * 설명 : 아이템을 스왑
    ***********************************************************/
    public void Swap(Slot slot, Vector3 pos)
    {
        //Debug.Log($"[InventoryManager] 스왑 함수 시작부분");
        //Slot firstSlot = NearSlot(pos);
        //Debug.Log($"[InventoryManager] 시작슬롯? : {firstSlot}");


        //if (slot == firstSlot || firstSlot == null)
        //{
        //    return;
        //}

        //if (!firstSlot.IsSlot())
        //{
        //    Debug.Log($"[InventoryManager] 스왑 함수 실행");
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
