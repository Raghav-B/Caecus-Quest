using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Card",menuName ="Card")]
public class Card : ScriptableObject
{
    public enum Rarity {
        COMMON, RARE, EPIC, LEGENDARY
    }

    public int cardID;
    public string cardName;
    public Rarity rarity;
    public string description;
    public float chanceToHit;
    public Sprite splashArt;

    public Character character;
}
