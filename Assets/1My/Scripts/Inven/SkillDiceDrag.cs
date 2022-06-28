/******************************************************************************
* 작 성 일 : 2022-06-27
* 내    용 : 전투화면 주사위를 관리함
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDiceDrag : MonoBehaviour
{
    public SkillDiceManager skillDiceManager;

    public Transform dragImage;

    private Image emptyImage;
    private Slot slot;

    private bool isCatch = false;

    public int diceNum;

    private void Awake()
    {
        emptyImage = dragImage.GetComponent<Image>();
        slot = GetComponent<Slot>();
    }

    /**********************************************************
    * 설명 : 슬롯을 처음 클릭했을 때
    ***********************************************************/
    public void Down()
    {
        if (!slot.IsSlot() && !isCatch)
        {
            return;
        }
        dragImage.gameObject.SetActive(true);
        emptyImage.sprite = slot.dice.image;
        diceNum = slot.dice.diceNum;
        isCatch = true;
        slot.Dice = null;
        //skillDiceManager.RemoveDice();

        dragImage.transform.position = Input.mousePosition;
    }

    /**********************************************************
    * 설명 : 누른 상태로 드래그
    ***********************************************************/
    public void Drag()
    {
        if (!slot.IsSlot() && !isCatch)
        {
            return;
        }
        dragImage.transform.position = Input.mousePosition;      
    }

    /**********************************************************
    * 설명 : 드래그 종료
    ***********************************************************/
    public void DragEnd()
    {
        if (!slot.IsSlot() && !isCatch)
        {
            return;
        }

        int i = skillDiceManager.NearSlot(Input.mousePosition);
        skillDiceManager.ChangeImage(i, diceNum);
    }

    /**********************************************************
    * 설명 : 마우스 버튼을 땠을 때
    ***********************************************************/
    public void Up()
    {
        if (!slot.IsSlot() && !isCatch)
        {
            return;
        }
        dragImage.gameObject.SetActive(false);
    }

}
