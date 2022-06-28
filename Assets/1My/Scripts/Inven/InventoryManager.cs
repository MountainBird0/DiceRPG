/******************************************************************************
* 작 성 일 : 2022-06-27
* 내    용 : 전체적인 인벤토리를 관리
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private UserData userdata;

    public Dice startDice1;
    public Dice startDice2;
    public Dice startDice3;

    public List<Dice> intactDice1;
    public List<Dice> intactDice2;
    public List<Dice> intactDice3;

    public List<Dice> dices;

    [SerializeField] private Transform diceSlotParent1;
    [SerializeField] private Transform diceSlotParent2;
    [SerializeField] private Transform diceSlotParent3;
    [SerializeField] private Transform bagSlotsParent;
    [SerializeField] private Transform smithyParent;

    [SerializeField] private Slot[] diceSlot1;
    [SerializeField] private Slot[] diceSlot2;
    [SerializeField] private Slot[] diceSlot3;
    [SerializeField] private Slot[] bagSlots;
    [SerializeField] private Slot[] smithySlots;

    public static InventoryManager instance;

    private void OnValidate()
    {
        diceSlot1 = diceSlotParent1.GetComponentsInChildren<Slot>();
        diceSlot2 = diceSlotParent2.GetComponentsInChildren<Slot>();
        diceSlot3 = diceSlotParent3.GetComponentsInChildren<Slot>();
        bagSlots = bagSlotsParent.GetComponentsInChildren<Slot>();
        smithySlots = smithyParent.GetComponentsInChildren<Slot>();
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
        userdata = GetComponentInParent<UserData>();
        Debug.Log($"[InventoryManager] 유저데이터 찾았니?{userdata}");
    }

    public void OnEnable()
    {
        //SmithyManager.instance.FreshEvenSlot();
        //for (int i = 0; i < bagSlots.Length; i++)
        //{
        //    if (bagSlots[i].Dice == null)
        //        break;
        //    dices.Add(bagSlots[i].Dice);
        //}
        for (int i = 0; i < userdata.dices.Count; i++)
        {
            dices.Add(userdata.dices[i]);
        }
        FreshSlot();
    }

    public void OnDisable()
    {
        userdata.dices.Clear();
        for(int i = 0; i < dices.Count; i++)
        {
            userdata.dices.Add(dices[i]);
        }
        dices.Clear();
    }

    private void Start()
    {
        for (int i = 0; i < diceSlot1.Length; i++)
        {
            intactDice1.Add(startDice1);
            intactDice2.Add(startDice2);
            intactDice3.Add(startDice3);
        }
        FreshIntactSlot(1);
        FreshIntactSlot(2);
        FreshIntactSlot(3);
        FreshSlot();
    }

    /**********************************************************
    * 설명 :인벤토리 상태 갱신
    ***********************************************************/
    public void FreshSlot()
    {
        int i = 0;
        for (; i < dices.Count && i < bagSlots.Length; i++)
        {
            bagSlots[i].Dice = dices[i];
        }
        for (; i < bagSlots.Length; i++)
        {
            bagSlots[i].Dice = null;
        }
    }

    /**********************************************************
    * 설명 : 주사위를 가방에 넣음
    ***********************************************************/
    public void GetDice(Dice dice)
    {
        if (dices.Count < bagSlots.Length)
        {
            //dices.Add(dice);
            userdata.dices.Add(dice);
            Debug.Log("유저데이터에 넣음");
            Debug.Log($"유저데이터 숫자{userdata.dices.Count}");
            FreshSlot();
        }
        else
        {
            Debug.Log("가방이 꽉 참");
        }
    }

    /**********************************************************
    * 설명 : 선택한 주사위를 지움  
    ***********************************************************/
    public void RemoveDice(int index)
    {
        Debug.Log($"[InventoryManager].HideDice() index? {index}");
        dices.RemoveAt(index);
        FreshSlot();
    }

    public void RemoveDice(int slotNum, int index)
    {
        if (slotNum == 1)
        {
            intactDice1.RemoveAt(index);
            Debug.Log($"[InventoryManager].초기화");
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
    * 설명 : 다이스를 내림
    ***********************************************************/
    public void DropDice(int index, Dice dice)
    {
        dices.Insert(index, dice);
        //dices.Add(dice);
        FreshSlot();
    }

    /**********************************************************
    * 설명 : 마우스와 가까운 슬롯을 반환
    ***********************************************************/
    public int[] NearSlot(Vector3 pos)
    {
        float min = 10000f;
        int slotNum = -1;
        int index = -1;

        for (int i = 0; i < bagSlots.Length; i++)
        {
            Vector2 sPos = bagSlots[i].transform.position;
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

        Debug.Log($"[InventoryManager]. 슬롯넘버:{slotNum}, 인덱스:{index}");
        int[] godata = { slotNum, index };
        return godata;
    }

    //////////////
    /// 주사위 1 완성
    /////////////

    /**********************************************************
    * 설명 : 장비창에 주사위를 장착
    ***********************************************************/
    public void AddIntactDice(Dice dice, int slotNum)
    {
        if (slotNum == 1)
        {
            if (intactDice1.Count < diceSlot1.Length)
            {
                intactDice1.Add(dice);
                FreshIntactSlot(slotNum);
            }
            else
            {
                Debug.Log("장비창이 꽉 참");
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
                Debug.Log("장비창이 꽉 참");
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
                Debug.Log("장비창이 꽉 참");
            }
        }

        if (slotNum == 4)
        {
            if (dices.Count < bagSlots.Length)
            {
                dices.Add(dice);
                FreshSlot();
            }
            else
            {
                Debug.Log("가방이 꽉 참");
            }
        }
    }

    /**********************************************************
    * 설명 : 장비창 정리
    ***********************************************************/
    public void FreshIntactSlot(int slotNum)
    {
        if (slotNum == 1)
        {
            int i = 0;
            for (; i < intactDice1.Count && i < diceSlot1.Length; i++)
            {
                diceSlot1[i].Dice = intactDice1[i];
            }
            for (; i < diceSlot1.Length; i++)
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

    /**********************************************************
    * 설명 : 대장간 인벤 상태 갱신
    ***********************************************************/
    public void FreshSmithySlot()
    {
        int i = 0;
        for (; i < dices.Count && i < smithySlots.Length; i++)
        {
            smithySlots[i].Dice = dices[i];
        }
        for (; i < smithySlots.Length; i++)
        {
            smithySlots[i].Dice = null;
        }
    }
}



/**********************************************************
    * 설명 : 아이템을 스왑
    ***********************************************************/
//public void Swap(Slot slot, Vector3 pos)
//{
//    //Debug.Log($"[InventoryManager] 스왑 함수 시작부분");
//    //Slot firstSlot = NearSlot(pos);
//    //Debug.Log($"[InventoryManager] 시작슬롯? : {firstSlot}");


//    //if (slot == firstSlot || firstSlot == null)
//    //{
//    //    return;
//    //}

//    //if (!firstSlot.IsSlot())
//    //{
//    //    Debug.Log($"[InventoryManager] 스왑 함수 실행");
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
   * 설명 : 그 부분의 아이템을 제거
   ***********************************************************/
////public void OutDice(int index)
////{
////    dices.RemoveAt(index);
////    FreshSlot();
//}

/**********************************************************
    * 설명 : 아이템을 원하는 위치에 드롭
    ***********************************************************/
//public void Drop(Dice dice, Vector3 pos)
//{
//    //int startSlot = NearSlot(Input.mousePosition);
//    //Debug.Log($"[InventoryManager] startSlot값은? {startSlot}");
//    //int i = startSlot;
//    //Debug.Log($"[InventoryManager] i값은? {i}");
//    //dices.Insert(i, dice);
//    //Debug.Log($"[InventoryManager] dice값은? {dice}");

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