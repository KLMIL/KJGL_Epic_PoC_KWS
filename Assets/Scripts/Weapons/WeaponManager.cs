/**********************************************************
 * Script Name: WeaponManager
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 모든 무기를 관리하며, 플레이어가 무기를 선택하고 사용하도록 지원.
 *   무기 목록을 배열로 저장하고, 인덱스로 무기를 전환
 *********************************************************/

using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    List<IWeapon> _weapons = new List<IWeapon>();
    int _currentWeaponIndex = 0;
    IWeapon _currentWeapon;


    private void Start()
    {
        // 무기 초기화
        // 무기 컴포넌트를 런타임에 동적으로 추가하는 방식. 
        // 시간복잡도 O(1)에 가까움
        // 장점: 무기 추가와 할당이 편리함
        // 단점: 런타임 오버헤드, 의존성 문제로 런타임 에러 가능성, Inspector 가시성 부족
        // 추후, 무기 수가 고정되는 시점에 Inspector 할당 방식으로 변경 요망.
        _weapons.Add(gameObject.AddComponent<WeaponKnife>());
        _weapons.Add(gameObject.AddComponent<WeaponSoysauce>());
        _weapons.Add(gameObject.AddComponent<WeaponSalt>());

        // 초기 무기 설정
        _currentWeapon = _weapons[_currentWeaponIndex];
        Debug.Log($"Equipped: {_currentWeapon.Name}");
    }

    public void Attack()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.Attack();
        }
    }

    public void SwitchWeapon(int index)
    {
        if (index >= 0 && index < _weapons.Count)
        {
            _currentWeaponIndex = index;
            _currentWeapon = _weapons[_currentWeaponIndex];
            Debug.Log($"Switched to: {_currentWeapon.Name}");
        }
    }

    public string GetCurrentWeaponName()
    {
        return _currentWeapon != null ? _currentWeapon.Name : "None";
    }
}
