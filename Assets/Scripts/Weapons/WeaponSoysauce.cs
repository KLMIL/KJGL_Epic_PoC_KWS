/**********************************************************
 * Script Name: WeaponSoysauce
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어의 무기 중, 원거리 단일 공격 무기인 "Soysauce"
 *********************************************************/

using UnityEngine;

public class WeaponSoysauce : MonoBehaviour, IWeapon
{
    public string Name => "Soysauce";
    public bool HasAmmo => true;
    public int Ammo => _ammo;
    
    int _ammo = 10; // 초기 잔탄수


    public void Attack()
    {
        Debug.Log("Soysauce: Throwing a soysauce");
        // PoC: 실제 구현은 투사체 프리펩 생성 및 발사
    }
}
