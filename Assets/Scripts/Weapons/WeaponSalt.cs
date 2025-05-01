/**********************************************************
 * Script Name: WeaponSalt
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어의 무기 중, 원거리 범위 공격 무기임 "Salt"
 *********************************************************/

using UnityEngine;

public class WeaponSalt : MonoBehaviour, IWeapon
{
    public string Name => "Salt";
    public bool HasAmmo => true;
    public int Ammo => _ammo;

    int _ammo = 5; // 초기 잔탄수

    public void Attack()
    {
        Debug.Log("Salt: Sprinkling salt in a wide area");
        // PoC: 실제 구현은 파티클 시스템 또는 SphereCast로 범위 공격
    }
}
