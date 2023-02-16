using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject m_slotPrefab;
    [SerializeField]
    GameObject m_itemPrefab;
    [SerializeField]
    UIGrid m_itemSlotGrid;
    [SerializeField]
    UISprite m_cursorSpr;
    List<ItemSlot> m_itemSlotList = new List<ItemSlot>();
    int m_maxSlot = 60;
    [SerializeField]
    Sprite[] m_iconSprites;
    [SerializeField]
    List<ItemData> m_itemDataList = new List<ItemData>();
    Dictionary<ItemType, ItemData> m_itemTable = new Dictionary<ItemType, ItemData>();
    public void CreateItem()
    {
        for (int i = 0; i < m_maxSlot; i++)
        {
            if (m_itemSlotList[i].IsEmpty)
            {
                var item = Instantiate(m_itemPrefab).GetComponent<Item>();
                var type = (ItemType)Random.Range(0, (int)ItemType.Max);
                var data = GetItemData(type);
                ItemInfo itemInfo = new ItemInfo() { itemData = data, count = Random.Range(1, 99)};
                item.SetItem(itemInfo, GetItemIcon(type));
                m_itemSlotList[i].SetSlot(item);
                break;
            }
        }
    }
    Sprite GetItemIcon(ItemType type)
    {
        Debug.Log((int)type);
        return m_iconSprites[(int)type];
    }
    void SetInventory()
    {
        for (int i = 0; i < m_maxSlot; i++)
        {
            CreateSlot();
        }
    }
    void InitItemTable()
    {
        for (int i = 0; i < m_itemDataList.Count; i++)
        {
            m_itemTable.Add(m_itemDataList[i].type, m_itemDataList[i]);
        }
    }
    ItemData GetItemData(ItemType type) => m_itemTable[type];
    void CreateSlot()
    {
        var obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(m_itemSlotGrid.transform); // m_itemSlotGrid의 좌표를 넘겨받는다.
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.transform.localRotation = Quaternion.identity;
        var slot= obj.GetComponent<ItemSlot>();
        m_itemSlotList.Add(slot);
    }
    void Start()
    {
        SetInventory();
        InitItemTable();
        m_cursorSpr.enabled = false;
    }
}
