/**********************************************************
 * Script Name: EnemyBase
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - ��� ���� �������� ������ �Ӽ��� ������ �����ϴ� �߻�Ŭ����
 *********************************************************/

using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _maxHealth = 100f;
    protected float _currentHealth;

    [SerializeField] protected float _attackCooldown = 2f;
    protected float _lastAttackTime;

    protected Transform playerTransform;


    protected virtual void Awake()
    {
        _currentHealth = _maxHealth;
        // �̺κ� �ָ��ϴ�. 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    protected virtual void Update()
    {
        if (Time.time >= _lastAttackTime + _attackCooldown)
        {
            Attack();
            _lastAttackTime = Time.time;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        EnemyManager.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

    protected abstract void Attack(); // �� ������ ���� ���� ����
}
