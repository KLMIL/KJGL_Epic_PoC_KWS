/**********************************************************
 * Script Name: UICooking
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 요리 UI canvas를 컨트롤할 스크립트
 *********************************************************/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICooking : MonoBehaviour
{
    [SerializeField] CookingManager _cookingManager;
    [SerializeField] GameObject _cookingPanel;
    [SerializeField] Button[] _craftButtons;
    [SerializeField] Recipe[] _recipes;

    private void Awake()
    {
        if (_cookingManager == null)
        {
            _cookingManager = FindObjectOfType<CookingManager>();
            if (_cookingManager == null)
            {
                Debug.LogError("CookingManager is not found");
            }
        }

        if (_cookingPanel == null)
        {
            Debug.LogError("CookingPanel not assigned");
        }

        // 일단 6개 아이템만 테스트
        if (_craftButtons.Length != 6 || _recipes.Length != 6)
        {
            Debug.LogError("CraftButtons or Recipes not properly assigned");
        }
        else
        {
            for (int i = 0; i < _craftButtons.Length; i++)
            {
                int index = i;
                _craftButtons[i].onClick.AddListener(() => CraftRecipe(index));
                TextMeshProUGUI text = _craftButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                if (text != null)
                {
                    text.text = $"{_recipes[i].RecipeName}\n({_recipes[i].RequiredIngredient.ItemName} x{_recipes[i].IngredientQuantity})";
                }
            }
        }
    }

    private void OnEnable()
    {
        UpdateCraftButtons();
    }

    private void UpdateCraftButtons()
    {
        for (int i = 0; i < _craftButtons.Length; i++)
        {
            bool canCraft = _cookingManager.CanCraftRecipe(_recipes[i]);
            _craftButtons[i].interactable = canCraft;
            Debug.Log($"Craft button {_recipes[i].RecipeName}: Interactable = {canCraft}");
        }
    }

    private void CraftRecipe(int index)
    {
        Debug.LogWarning("Here?");
        if (index < 0 || index >= _recipes.Length) return;

        Debug.Log($"Crafting recipe: {_recipes[index].RecipeName}");
        _cookingManager.CraftRecipe(_recipes[index]);
        UpdateCraftButtons();
    }
}
