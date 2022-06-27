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
        Debug.Log($"[ItemDrag] 슬롯 머임 {slot}");
        dragImage.gameObject.SetActive(true);
        emptyImage.sprite = slot.dice.image;

        curDice = slot.dice;
        int[] i = InventoryManager.instance.NearSlot(Input.mousePosition);
        InventoryManager.instance.HideDice(i[1]);

        dragImage.transform.position = Input.mousePosition;

        //InventoryManager.instance.FreshSlot();
        //int i = InventoryManager.instance.NearSlot(Input.mousePosition);
        // Debug.Log($"[ItemDrag] i값은? {i}");
        // curDice = slot.dice;
        //// InventoryManager.instance.OutDice(i);
        // InventoryManager.instance.TransForward(i);
        // //
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

        int[] i = InventoryManager.instance.NearSlot(Input.mousePosition);
        Debug.Log($"[ItemDrag] 추가할 다이스 뭐임 {curDice}");

        InventoryManager.instance.DropDice(i[1], curDice);
    }

    /**********************************************************
    * 설명 : 마우스 버튼을 땠을 때
    ***********************************************************/
    public void Up()
    {
        if (!slot.IsSlot())
        {
            return;
        }

        dragImage.gameObject.SetActive(false);
        //InventoryManager.instance.FreshSlot();
        //slot.image.sprite = emptyImage.sprite;
    }
}
