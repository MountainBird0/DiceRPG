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

    public int[] skillActives = { 0, 0 };

    private int num1;
    private int num2;

    private void OnValidate()
    {
        skillDice1 = skillDiceParent1.GetComponentInChildren<Slot>();
        skillDice2 = skillDiceParent2.GetComponentInChildren<Slot>();
        skillDice3 = skillDiceParent3.GetComponentInChildren<Slot>();
    }

    public void Update()
    {
        if (skillDice1.Dice == null && skillDice2.Dice == null && skillDice3.Dice == null)
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

    /**********************************************************
    * 설명 : 버튼의 이미지를 변경
    ***********************************************************/
    public void ChangeImage(int slotNum, int diceNum)
    {
        if (slotNum == 0)
        {
            skillActives[0] = 1;
            if (diceNum == 1 || diceNum == 2)
            {
                skillbuttons[slotNum].GetComponent<Image>().sprite =
                    Resources.Load("Skill/RubyGround", typeof(Sprite)) as Sprite;
            }

            if (diceNum == 3 || diceNum == 4)
            {
                skillbuttons[slotNum].GetComponent<Image>().sprite =
                    Resources.Load("Skill/GroundSlam", typeof(Sprite)) as Sprite;
            }

            num1 = diceNum;
        }

        if (slotNum == 1)
        {
            skillActives[1] = 1;
            if (diceNum == 1 || diceNum == 2)
            {
                skillbuttons[slotNum].GetComponent<Image>().sprite =
                    Resources.Load("Skill/IceShot", typeof(Sprite)) as Sprite;
            }
            if (diceNum == 3 || diceNum == 4)
            {
                skillbuttons[slotNum].GetComponent<Image>().sprite =
                    Resources.Load("Skill/IceGround", typeof(Sprite)) as Sprite;
            }
            num2 = diceNum;
        }
    }

    public void OnClickSkillSlot1()
    {
        if (skillActives[0] == 1)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (num1 == 1 || num1 == 2)
            {
                player.GetComponent<PlayerController>().RubyAttack();
            }
            if (num1 == 3 || num1 == 4)
            {
                player.GetComponent<PlayerController>().GroundSlap();
            }
            skillbuttons[0].GetComponent<Image>().sprite =
                    Resources.Load("Skill/RedIcon", typeof(Sprite)) as Sprite;
            skillActives[0] = 0;
        }     
    }
    public void OnClickSkillSlot2()
    {
        if (skillActives[1] == 1)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (num2 == 1 || num2 == 2)
            {
                player.GetComponent<PlayerController>().LineShot();
            }
            if (num2 == 3 || num2 == 4)
            {
                player.GetComponent<PlayerController>().IceAttack();
            }

            

            skillbuttons[1].GetComponent<Image>().sprite =
                    Resources.Load("Skill/BlueIcon", typeof(Sprite)) as Sprite;
            skillActives[1] = 0;
        }
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

            if (dis < min)
            {
                min = dis;
                ButtonNum = i;
            }
        }
        return ButtonNum;
    }
}
