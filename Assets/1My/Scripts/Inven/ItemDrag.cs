using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour
{
    public Transform dragImage;

    private Image emptyImage;
    private Slot slot;

    private Dice curDice;

    private void Awake()
    {       
        //dragImage = GameObject.FindGameObjectWithTag("Drag").transform;
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
        //float size = slot.transform.GetComponent<RectTransform>)().sizeDelta.x
        emptyImage.sprite = slot.Dice.image;
        //slot.dice.image = null;
        int i = InventoryManager.instance.NearSlot(Input.mousePosition);
        Debug.Log($"[ItemDrag] i값은? {i}");
        curDice = slot.Dice;
        InventoryManager.instance.OutDice(i);
        //InventoryManager.instance.FreshSlot();
        dragImage.transform.position = Input.mousePosition;

    }

    /**********************************************************
    * 설명 : 누른 상태로 드래그
    ***********************************************************/
    public void Drag()
    {
        if(!slot.IsSlot())
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
        if (!slot.IsSlot())
        {
            return;
        }
        InventoryManager.instance.Drop(curDice, Input.mousePosition);
        //InventoryManager.instance.Swap(slot, dragImage.transform.position);
    }

    /**********************************************************
    * 설명 : 마우스 버튼을 땠을 때
    ***********************************************************/
    public void Up()
    {
        //if (!slot.IsSlot())
        //{
        //    return;
        //}
        
        dragImage.gameObject.SetActive(false);
        //slot.image.sprite = emptyImage.sprite;
    }
}
