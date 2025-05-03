/**********************************************************
 * Script Name: Recipe
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description: 
 * - 요리 레시피를 정의하는 Scriptable Object
 *********************************************************/

using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    public string RecipeName;
    public Item Output;
    public Item RequiredIngredient;
    public int IngredientQuantity = 1;

    // 추가 재료
    public Item RequiredSeasoning;
    public int SeasoningQuantity = 0;
}
