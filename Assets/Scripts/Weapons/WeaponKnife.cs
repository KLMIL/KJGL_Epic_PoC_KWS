/**********************************************************
 * Script Name: WeaponKnife
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어의 무기 중, 근접 무기 "Knife"
 *********************************************************/

using UnityEngine;

public class WeaponKnife : MonoBehaviour, IWeapon
{
    public string Name => "Knife";
    public bool HasAmmo => false;
    public int Ammo => 0;

    public void Attack()
    {
        Debug.Log("Knife: Quick stab attack");
        // PoC: 실제 구현은 애니메이션 트리거 또는 Raycast 히트 감지
    }
}
