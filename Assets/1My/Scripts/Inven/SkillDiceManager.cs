/******************************************************************************
* 작 성 일 : 2022-06-27
* 내    용 : 전투화면 주사위를 관리함
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDiceManager : MonoBehaviour
{
    [SerializeField] private Transform skillDiceParent1;
    [SerializeField] private Transform skillDiceParent2;
    [SerializeField] private Transform skillDiceParent3;

    [SerializeField] private Slot skillDice1;
    [SerializeField] private Slot skillDice2;
    [SerializeField] private Slot skillDice3;

    public Button[] skillbuttons;

    public int[] skillActives = {0,0};

    private int num;

    private void OnValidate()
    {
        skillDice1 = skillDiceParent1.GetComponentInChildren<Slot>();
        skillDice2 = skillDiceParent2.GetComponentInChildren<Slot>();
        skillDice3 = skillDiceParent3.GetComponentInChildren<Slot>();
    }

    public void Start()
    {
        GetRanDice();
    }

    public void Update()
    {
        if(skillDice1.Dice == null && skillDice2.Dice == null && skillDice3.Dice == null)
        {
            GetRanDice();

        }
    }

    public void GetRanDice()
    {
        int num = Random.Range(0, 6);
        skillDice1.Dice = InventoryManager.instance.intactDice1[num];
        skillDice2.Dice = InventoryManager.instance.intactDice2[num];
        skillDice3.Dice = InventoryManager.instance.intactDice3[num];
    }

    public void RemoveDice()
    {
         //= null;
    }

    /**********************************************************
    * 설명 : 버튼의 이미지를 변경
    ***********************************************************/
    public void ChangeImage(int slotNum, int diceNum)
    {
        if(slotNum == 0)
        {
            skillActives[0] = 1;
            if(diceNum == 1)
            {
                skillbuttons[slotNum].GetComponent<Image>().sprite =
                    Resources.Load("Skill/RubyGround", typeof(Sprite)) as Sprite;
            }

            if (diceNum == 2)
            {
                skillbuttons[slotNum].GetComponent<Image>().sprite =
                    Resources.Load("Skill/GroundSlam", typeof(Sprite)) as Sprite;
            }
        }

        num = diceNum;
    }



    /**********************************************************
    * 설명 : 마우스와 가까운 스킬칸을 반환
    ***********************************************************/
    public int NearSlot(Vector3 pos)
    {
        float min = 10000f;
        int ButtonNum = -1;

        for (int i = 0; i < skillbuttons.Length; i++)
        {
            Vector2 sPos = skillbuttons[i].transform.position;
            float dis = Vector2.Distance(sPos, pos);

            if(dis < min)
            {
                min = dis;
                ButtonNum = i;
            }
        }
        return ButtonNum;
    }


    public void OnClickSkillSlot1()
    {
        //Debug.Log("[UiManager]스킬버튼 누름");
        if(skillActives[0] == 1)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if(num == 1)
            {
                player.GetComponent<PlayerController>().RubyAttack();
            }
            if (num == 2)
            {
                player.GetComponent<PlayerController>().GroundSlap();
            }
            skillbuttons[0].GetComponent<Image>().sprite =
                    Resources.Load("Skill/RedIcon", typeof(Sprite)) as Sprite;
            skillActives[0] = 0;
        }
    }

}
