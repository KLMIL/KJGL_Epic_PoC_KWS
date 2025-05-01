/**********************************************************
 * Script Name: EnemyBase
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 모든 적이 공통으로 가지는 속성과 동작을 정의하는 추상클래스
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
        // 이부분 애매하다. 
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

    protected abstract void Attack(); // 각 몬스터의 고유 공격 구현
}
