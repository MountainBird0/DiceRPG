using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dice.asset", menuName = "Item/Dice")]
public class Dice : ScriptableObject
{
    public Sprite image;
    public int diceNum;
}
