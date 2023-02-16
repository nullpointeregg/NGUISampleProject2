using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    Item m_item;
    public bool isSelected;
    public bool IsEmpty { get { return m_item == null; } }
    public void SetSlot(Item item)
    {
        m_item = item;
        m_item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localScale= Vector3.one;
    }
    public void OnSelect()
    {
        
    }
    void Start()
    {
        
    }
}
