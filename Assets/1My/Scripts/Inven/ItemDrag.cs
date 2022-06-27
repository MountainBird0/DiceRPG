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
    * ���� : ������ ó�� Ŭ������ ��
    ***********************************************************/
    public void Down()
    {
        if (!slot.IsSlot())
        {
            return;
        }
        Debug.Log($"[ItemDrag] ���� ���� {slot}");
        dragImage.gameObject.SetActive(true);
        emptyImage.sprite = slot.dice.image;

        curDice = slot.dice;
        int[] i = InventoryManager.instance.NearSlot(Input.mousePosition);
        InventoryManager.instance.HideDice(i[1]);

        dragImage.transform.position = Input.mousePosition;

        //InventoryManager.instance.FreshSlot();
        //int i = InventoryManager.instance.NearSlot(Input.mousePosition);
        // Debug.Log($"[ItemDrag] i����? {i}");
        // curDice = slot.dice;
        //// InventoryManager.instance.OutDice(i);
        // InventoryManager.instance.TransForward(i);
        // //
    }

    /**********************************************************
    * ���� : ���� ���·� �巡��
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
    * ���� : �巡�� ����
    ***********************************************************/
    public void DragEnd()
    {
        if (!slot.IsSlot())
        {
            return;
        }

        int[] i = InventoryManager.instance.NearSlot(Input.mousePosition);
        Debug.Log($"[ItemDrag] �߰��� ���̽� ���� {curDice}");

        InventoryManager.instance.DropDice(i[1], curDice);
    }

    /**********************************************************
    * ���� : ���콺 ��ư�� ���� ��
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
