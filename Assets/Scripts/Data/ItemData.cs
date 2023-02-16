using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Icon1,
    Icon2,
    Icon3,
    Icon4,
    Icon5,
    Icon6,
    Icon7,
    Icon8,
    Icon9,
    Icon10,
    Max
}
[System.Serializable]
public struct ItemData
{
    public ItemType type;
    public int iconIdx;
    public float value;
}
public struct ItemInfo
{
    public ItemData itemData;
    public int count;
}
