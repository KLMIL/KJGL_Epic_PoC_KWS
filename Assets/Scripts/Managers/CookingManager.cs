/**********************************************************
 * Script Name: CookingManager
 * Author: 김우성
 * Date Created: 2025-05-03
 * Last Modified: 0000-00-00
 * Description: 
 * - 요리하기 로직을 관리하는 스크립트
 *********************************************************/

using UnityEngine;
using Enums;

public class CookingManager : MonoBehaviour
{
    [SerializeField] InventoryManager _inventoryManager;
    [SerializeField] GameObject _cookingPanel;

    [SerializeField] KeyCode _toggleKey = KeyCode.T;


    private void Update()
    {
        if (Input.GetKeyDown(_toggleKey))
        {
            Debug.Log("Cook panel toggle on");
            _cookingPanel.SetActive(!_cookingPanel.activeSelf);
        }
    }


    public bool CanCraftRecipe(Recipe recipe)
    {
        if (recipe.RequiredIngredient == null) return false;

        foreach (InventorySlot slot in _inventoryManager.GetSlots(ItemType.Ingredient))
        {
            if (slot.Item == recipe.RequiredIngredient && slot.Quantity >= recipe.IngredientQuantity)
            {
                Debug.Log($"Can craft {recipe.RecipeName}: {recipe.RequiredIngredient} x{recipe.IngredientQuantity} available");
                return true;
            }
        }
        Debug.Log($"Cannot craft {recipe.RecipeName}: Need {recipe.RequiredIngredient.ItemName} x{recipe.IngredientQuantity}");
        return false;
    }

    public void CraftRecipe(Recipe recipe)
    {
        if (!CanCraftRecipe(recipe)) return;

        foreach (InventorySlot slot in _inventoryManager.GetSlots(ItemType.Ingredient))
        {
            if (slot.Item == recipe.RequiredIngredient)
            {
                slot.Quantity -= recipe.IngredientQuantity;
                Debug.Log($"Consumed {recipe.RequiredIngredient.ItemName} x{recipe.IngredientQuantity}");
                if (slot.Quantity <= 0)
                {
                    _inventoryManager.GetSlots(ItemType.Ingredient).Remove(slot);
                }
                break;
            }
        }

        _inventoryManager.AddItem(recipe.Output, 1);
        Debug.Log($"Crafted {recipe.Output.ItemName}");
    }
}
