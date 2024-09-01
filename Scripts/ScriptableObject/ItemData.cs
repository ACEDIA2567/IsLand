using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemInfo
{
    string ItemText();

    void ItemAdd();
}

public interface IConsumable
{
    void Use();
}

public enum ConsumableType
{
    Hp,
    Sp,
    Ep,
    Wp,
    SpeedUp,
    JumpUp
}

public enum ItemType
{
    Consumable,
    Resource,
    Equipment,
    Build
}

[Serializable]
public class ConsumableData
{
    public ConsumableType consumableType;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    public int maxCount;
    public int count;

    public ConsumableData[] consumableData;
    public float delayTime;

    public GameObject ViewObject;
}
