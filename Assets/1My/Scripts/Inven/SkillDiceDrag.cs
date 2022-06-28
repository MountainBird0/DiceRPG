/******************************************************************************
* �� �� �� : 2022-06-27
* ��    �� : ����ȭ�� �ֻ����� ������
* �� �� �� :
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
    * ���� : ������ ó�� Ŭ������ ��
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
    * ���� : ���� ���·� �巡��
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
    * ���� : �巡�� ����
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
    * ���� : ���콺 ��ư�� ���� ��
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
