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
    * ���� : ���� ���·� �巡��
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
