/**********************************************************
 * Script Name: IWeapon
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 모든 무기의 베이스가 되는 인터페이스. 
 *********************************************************/

using UnityEngine;

public interface IWeapon
{
    string Name { get; } // 무기 이름
    void Attack(); // 공격 메소드
    bool HasAmmo { get; } // 잔탄수 존재하는지 여부
    int Ammo { get; } // 현재 잔탄수
}
