/**********************************************************
 * Script Name: Health
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
 * Description: 
 * - 캐릭터의 HP 상태와 피격을 처리하는 스크립트
 * - 가장 많이 피해입은 무기를 기록
 *********************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;
    float _currentHealth;

    Dictionary<string, float> _damageByWeapon = new Dictionary<string, float>();
    public UnityEvent<string, float> OnDeathWithTopWeapon; // 사망시 최대 피해 대미지 무기 전달

    public UnityEvent OnDeath; // 사망시 호출할 이벤트

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage, string weaponName)
    {
        _currentHealth -= damage;
        Debug.Log($"{gameObject.name} Health: {_currentHealth}");

        if (!string.IsNullOrEmpty(weaponName))
        {
            if (_damageByWeapon.ContainsKey(weaponName))
            {
                _damageByWeapon[weaponName] += damage;
            }
            else
            {
                _damageByWeapon.Add(weaponName, damage);
            }
        }


        if (_currentHealth <= 0)
        {
            // 게임 오버 로직
            Debug.Log($"{gameObject.name} Dead");

            // 가장 많은 피해를 입힌 무기 찾기
            string topWeapon = "Unknown";
            float topDamage = 0f;
            foreach (var pair in _damageByWeapon)
            {
                if (pair.Value > topDamage)
                {
                    topWeapon = pair.Key;
                    topDamage = pair.Value;
                }
            }
            OnDeathWithTopWeapon.Invoke(topWeapon, topDamage);
            //OnDeath.Invoke(); // 무기 정보 전달 함수 사용을 위해 DEPRECATED

        }
    }
}
