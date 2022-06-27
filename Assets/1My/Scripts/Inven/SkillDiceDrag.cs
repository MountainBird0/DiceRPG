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
        if (!slot.IsSlot())
        {
            return;
        }
        dragImage.gameObject.SetActive(true);
        emptyImage.sprite = slot.dice.image;

        slot.dice.image = null;
        //skillDiceManager.RemoveDice();
        dragImage.transform.position = Input.mousePosition;
    }

    /**********************************************************
    * 설명 : 누른 상태로 드래그
    ***********************************************************/
    public void Drag()
    {
        if (!slot.IsSlot())
        {
            return;
        }
        dragImage.transform.position = Input.mousePosition;
        //slot.dice = null;
        
    }

}
