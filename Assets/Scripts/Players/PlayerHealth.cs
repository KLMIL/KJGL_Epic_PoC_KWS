/**********************************************************
 * Script Name: PlayerHealth
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 플레이어 캐릭터의 HP 상태와 피격을 처리하는 스크립트
 *********************************************************/

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;
    float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Player Health: {_currentHealth}");
        if (_currentHealth <= 0)
        {
            // 게임 오버 로직
            Debug.Log("Player Dead");
            //Destroy(gameObject);
        }
    }
}
