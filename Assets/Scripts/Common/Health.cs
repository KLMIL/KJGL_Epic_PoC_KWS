/**********************************************************
 * Script Name: Health
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
 * Description: 
 * - 캐릭터의 HP 상태와 피격을 처리하는 스크립트
 *********************************************************/

using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;
    float _currentHealth;

    public UnityEvent OnDeath; // 사망시 호출할 이벤트

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log($"{gameObject.name} Health: {_currentHealth}");
        if (_currentHealth <= 0)
        {
            // 게임 오버 로직
            Debug.Log($"{gameObject.name} Dead");
            OnDeath.Invoke();
        }
    }
}
