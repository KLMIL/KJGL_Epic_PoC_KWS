/**********************************************************
 * Script Name: EnemyBase
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
 * Description: 
 * - 모든 적이 공통으로 가지는 속성과 동작을 정의하는 추상클래스
 *********************************************************/

using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    // 2025-05-04 KWS
    // DEPRECATED
    // Health.cs에서 TakeDamage 정의

    //[SerializeField] protected float _maxHealth = 100f;
    //protected float _currentHealth;

    [SerializeField] protected float _attackCooldown = 2f;
    protected float _lastAttackTime;

    protected Transform playerTransform;

    protected Health _health;

    protected UILogManager _logManager;


    protected virtual void Awake()
    {
        //_currentHealth = _maxHealth;
        // 이부분 애매하다. 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        _health = GetComponent<Health>();
        if (_health == null)
        {
            Debug.LogError($"{gameObject.name}: Health component not found");
        }
        else
        {
            //_health.OnDeath.AddListener(Die);
            _health.OnDeathWithTopWeapon.AddListener(Die);
        }

        _logManager = FindObjectOfType<UILogManager>();
        if (_logManager == null)
        {
            Debug.LogError("UILogManager not found in scene");
        }
    }

    protected virtual void Update()
    {
        if (Time.time >= _lastAttackTime + _attackCooldown)
        {
            // 테스트를 위해, 공격 기능 중지
            //Attack(); 
            _lastAttackTime = Time.time;
        }
    }

    // 2025-05-04 KWS
    // DEPRECATED
    // Health.cs에서 TakeDamage 정의
    //public virtual void TakeDamage(float damage)
    //{
    //    _currentHealth -= damage;
    //    if (_currentHealth <= 0)
    //    {
    //        Die();
    //    }
    //}

    // 2025-05-04 KWS
    // DEPRECATED
    // 무기 정보 전달을 위해 변경
    //protected virtual void Die()
    //{
    //    Debug.Log($"{gameObject.name} Die");
    //    EnemyManager.Instance.RemoveEnemy(this);
    //    Destroy(gameObject);
    //}

    protected virtual void Die(string topWeapon, float topDamage)
    {
        _logManager?.AddLog($"<color=red>{gameObject.name} Dead, Top Damage: {topWeapon} ({topDamage} damage</color>");
        Debug.Log($"Removing {gameObject.name} from EnemyManager");
        EnemyManager.Instance.RemoveEnemy(this);
        Debug.Log($"Destroying {gameObject.name}. Active: {gameObject.activeSelf}");
        Destroy(gameObject);
    }

    protected abstract void Attack(); // 각 몬스터의 고유 공격 구현

    protected virtual void OnDestroy()
    {
        if (_health != null)
        {
            //_health.OnDeath.RemoveListener(Die);
            _health.OnDeathWithTopWeapon.RemoveListener(Die);
        }
    }
}
