/**********************************************************
 * Script Name: PlayerHealth
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - �÷��̾� ĳ������ HP ���¿� �ǰ��� ó���ϴ� ��ũ��Ʈ
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
            // ���� ���� ����
            Debug.Log("Player Dead");
            //Destroy(gameObject);
        }
    }
}
