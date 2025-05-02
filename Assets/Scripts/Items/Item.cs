/**********************************************************
 * Script Name: Item
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 아이템 데이터를 정의하는 ScriptableObject
 *********************************************************/

using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public ItemType type;
    public int MaxStackSize = 99;
}
