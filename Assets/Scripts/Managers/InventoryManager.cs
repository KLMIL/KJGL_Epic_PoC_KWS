/**********************************************************
 * Script Name: InventoryManager
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어 인벤토리 관리, 조미료와 식재료 탭
 *********************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[System.Serializable]
public class InventorySlot
{
    public Item Item;
    public int Quantity;
    public InventorySlot(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }
}

public class InventoryManager : MonoBehaviour
{
    [SerializeField] int _maxSlotsPerTab = 10; // 탭당 최대 슬롯 수
    [SerializeField] List<InventorySlot> _seasoningSlots = new List<InventorySlot>();
    [SerializeField] List<InventorySlot> _ingredientSlots = new List<InventorySlot>();

    public event Action OnInventoryChanged; // 인벤토리 변경 이벤트

    public bool AddItem(Item item, int quantity = 1)
    {
        List<InventorySlot> targetSlots = item.type == ItemType.Seasoning ? _seasoningSlots : _ingredientSlots;

        // 기존 슬롯에 추가
        foreach (InventorySlot slot in targetSlots)
        {
            if (slot.Item == item && slot.Quantity < item.MaxStackSize)
            {
                int space = item.MaxStackSize - slot.Quantity;
                int addQuantity = Mathf.Min(quantity, space);
                slot.Quantity += addQuantity;
                OnInventoryChanged?.Invoke();
                return quantity == 0;
            }
        
        }
        // 새 슬롯에 추가
        if (targetSlots.Count < _maxSlotsPerTab && quantity > 0)
        {
            targetSlots.Add(new InventorySlot(item, Mathf.Min(quantity, item.MaxStackSize)));
            OnInventoryChanged?.Invoke();
            return true;
        }

        Debug.Log($"Cannot add {item.ItemName}: {item.type} tab full");
        return false;
    }

    public void RemoveItem(Item item, int quantity = 1)
    {
        List<InventorySlot> targetSlots = item.type == ItemType.Seasoning ? _seasoningSlots : _ingredientSlots;
        for (int i = targetSlots.Count - 1; i >= 0; i--)
        {
            if (targetSlots[i].Item == item)
            {
                targetSlots[i].Quantity -= quantity;
                if (targetSlots[i].Quantity <= 0)
                {
                    targetSlots.RemoveAt(i);
                }
                OnInventoryChanged?.Invoke();
                return;
            }
        }
        Debug.Log($"Cannot remove {item.ItemName}: Not found");
    }

    public List<InventorySlot> GetSlots(ItemType type)
    {
        return type == ItemType.Seasoning ? _seasoningSlots : _ingredientSlots;
    }
}
