using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] public Image image;

    public Dice dice;

    private bool isSlot = false;
    public bool IsSlot() { return isSlot; }

    public Dice Dice
    {
        get { return dice; }
        set
        {
            dice = value;
            if (dice != null)
            {
                image.sprite = Dice.image;
                image.color = new Color(1, 1, 1, 1);
                isSlot = true;
            }
            else
            {
                image.sprite = null;
                image.color = new Color(1, 1, 1, 0);
                isSlot = false;
            }
        }
    }
}

