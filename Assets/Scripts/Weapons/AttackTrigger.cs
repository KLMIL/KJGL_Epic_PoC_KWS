/**********************************************************
 * Script Name: AttackTrigger
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 공격 프리펩의 트리거 콜라이더로 적 감지 및 대미지 적용
 *********************************************************/

using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] int _damage = 10;
    HashSet<Collider2D> _hitEnemies = new HashSet<Collider2D>();
    Projectile _projectile;

    private void Awake()
    {
        _projectile = GetComponent<Projectile>();
    }

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_hitEnemies.Contains(collision))
        {
            _hitEnemies.Add(collision);
            Debug.Log($"Hit enemy with {gameObject.name}");
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(_damage);
            }
            if (_projectile != null)
            {
                _projectile.HitEnemy();
            }
        }
    }
}