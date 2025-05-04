/**********************************************************
 * Script Name: Item
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 2025-05-04
 * Description
 * - 아이템 데이터를 정의하는 ScriptableObject
 * - 드롭 확률 추가
 *********************************************************/

using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public ItemType type;
    public int MaxStackSize = 99;

    public float DropChance = 1.0f; // 드롭 확률, 0 ~ 1. 테스트를 위해 100%
    public string RequiredWeapon; // 이 무기로 죽였을 때 드롭. 빈 문자열 = 모든 무기
}
