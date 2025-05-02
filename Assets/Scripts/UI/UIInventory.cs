/**********************************************************
 * Script Name: UIInventory
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 인벤토리 UI, 조미료/식재료 탭 및 슬롯 표시
 *********************************************************/

using Enums;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] GameObject _inventoryPanel; // 인벤토리 패널
    [SerializeField] Button _seasoningTabButton; // 조미료 탭 버튼
    [SerializeField] Button _ingredientTabButton; // 식재료 탭 버튼
    [SerializeField] Transform _slotContainer; // 슬롯 그리드
    [SerializeField] GameObject _slotPrefab; // 슬롯 프리팹
    [SerializeField] KeyCode _toggleKey = KeyCode.Tab; // 인벤토리 토글 키

    InventoryManager _inventoryManager;
    ItemType _currentTab = ItemType.Seasoning; // 현재 탭
    List<GameObject> _slotObjects = new List<GameObject>();

    private void Awake()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
        if (_inventoryManager == null )
        {
            Debug.LogError("InventoryManager not found");
        }
        _inventoryPanel.SetActive(false);

        _seasoningTabButton.onClick.AddListener(() => SetTab(ItemType.Seasoning));
        _ingredientTabButton.onClick.AddListener(() => SetTab(ItemType.Ingredient));
    }

    private void OnEnable()
    {
        _inventoryManager.OnInventoryChanged += UpdateUI;
    }

    private void OnDisable()
    {
        _inventoryManager.OnInventoryChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_toggleKey)) 
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        }
    }

    private void SetTab(ItemType tab)
    {
        Debug.Log($"Inventory tab Setted: {tab}");
        _currentTab = tab;
        UpdateUI();
    }

    private void UpdateUI()
    {
        // 기존 슬롯 제거
        foreach (GameObject slotObj in _slotObjects)
        {
            Destroy(slotObj);
        }
        _slotObjects.Clear();

        // 현재 탭 슬롯 생성
        List<InventorySlot> slots = _inventoryManager.GetSlots(_currentTab);
        foreach (var slot in slots)
        {
            GameObject slotObj = Instantiate(_slotPrefab, _slotContainer);
            _slotObjects.Add(slotObj);

            TextMeshProUGUI text = slotObj.GetComponentInChildren<TextMeshProUGUI>();
            text.text = $"{slot.Item.ItemName}\nx{slot.Quantity}";
        }
    }
}
