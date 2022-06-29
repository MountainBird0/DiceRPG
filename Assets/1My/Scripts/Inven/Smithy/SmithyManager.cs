using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class SmithyManager : MonoBehaviour
{
    private UserData userdata;

    public Sprite[] diceImage;
    public Dice[] diceList;
    private int curDiceNum;

    public static SmithyManager instance;

    public Dice anvilDice;

    public List<Dice> dices;

    [SerializeField] private Transform anvilSlotParent;
    [SerializeField] private Transform bagSlotsParent;
    [SerializeField] private Transform smithyParent;

    [SerializeField] private Slot anvilSlots;
    [SerializeField] private Slot[] bagSlots;
    [SerializeField] private Slot[] smithySlots;

    public TextMeshProUGUI upgradeCountText;
    private int upgradeCount;


    private int earlyDicenum;

    private void OnValidate()
    {
        anvilSlots = anvilSlotParent.GetComponentInChildren<Slot>();
        bagSlots = bagSlotsParent.GetComponentsInChildren<Slot>();
        smithySlots = smithyParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 SmithyManager 존재합니다!");
            Destroy(gameObject);
        }

        userdata = GetComponentInParent<UserData>();
    }

    public void OnEnable()
    {
        //InventoryManager.instance.FreshSmithySlot();
        //for (int i = 0; i < smithySlots.Length; i++)
        //{
        //    if (smithySlots[i].Dice == null)
        //        break;
        //    dices.Add(smithySlots[i].Dice);
        //}
        for (int i = 0; i < userdata.dices.Count; i++)
        {
            dices.Add(userdata.dices[i]);
        }
        FreshSmithySlot();

        SetUpgradeCount();
    }

    public void OnDisable()
    {
        userdata.dices.Clear();
        for (int i = 0; i < dices.Count; i++)
        {
            userdata.dices.Add(dices[i]);
        }
        dices.Clear();
    }

    /**********************************************************
    * 설명 : 주사위를 모루에 넣음
    ***********************************************************/
    public void AddAnvilSlot(Dice dice, int index)
    {
        //SetDiceList();
        //Debug.Log("[SmithyManager] 안비어있나봐");
        if (anvilSlots.Dice == null)
        {
            earlyDicenum = dice.diceNum;

            curDiceNum = dice.diceNum;
            anvilSlots.Dice = dice;
            dices.RemoveAt(index);
            FreshSmithySlot();
        }
    }

    /**********************************************************
    * 설명 : 주사위를 모루에서 뺌
    ***********************************************************/
    public void RemoveAnvilSlot(Dice dice)
    {
        anvilSlots.Dice = null;
        dices.Add(dice);
        FreshSmithySlot();
    }

    /**********************************************************
    * 설명 : 슬롯 정렬
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

    /**********************************************************
    * 설명 : 마우스와 가까운 슬롯을 반환
    ***********************************************************/
    public int NearSlot(Vector3 pos)
    {
        float min = 10000f;
        int index = -1;

        for (int i = 0; i < smithySlots.Length; i++)
        {
            Vector2 sPos = smithySlots[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);

            if (dis < min)
            {
                min = dis;
                index = i;
            }
        }
        return index;
    }


    /**********************************************************
    * 설명 : 인벤 상태 갱신
    ***********************************************************/
    public void FreshEvenSlot()
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
    * 설명 : 강화 UP버튼 누름
    ***********************************************************/
    public void OnClickUp()
    {
        Debug.Log("[SmithyManager] 강화버튼 누름");
        Debug.Log($"[SmithyManager] {curDiceNum}");
        if (0 > curDiceNum || curDiceNum > 5 || upgradeCount == 0)
            return;

        anvilSlots.Dice = diceList[curDiceNum];
        curDiceNum = anvilSlots.Dice.diceNum;

        upgradeCount--;
        upgradeCountText.text = upgradeCount.ToString();
    }

    /**********************************************************
    * 설명 : 강화 Down버튼 누름
    ***********************************************************/
    public void OnClickDown()
    {
        Debug.Log("[SmithyManager] 다운버튼 누름");
        Debug.Log($"[SmithyManager] {curDiceNum}");

        if (1 > curDiceNum || curDiceNum > 6 || upgradeCount == 6 ||
            earlyDicenum == curDiceNum)
            return;

        anvilSlots.Dice = diceList[curDiceNum - 2];
        curDiceNum = anvilSlots.Dice.diceNum;

        upgradeCount++;
        upgradeCountText.text = upgradeCount.ToString();
    }

    /**********************************************************
    * 설명 : 입장했을 때 강화 횟수 설정
    ***********************************************************/
    public void SetUpgradeCount()
    {
        upgradeCount = 6;
        upgradeCountText.text = upgradeCount.ToString();
    }
}
