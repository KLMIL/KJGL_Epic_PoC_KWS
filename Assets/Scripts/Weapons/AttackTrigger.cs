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

    public delegate void DamageEventHandler(string weaponName, int damage, string enemyName);
    public static event DamageEventHandler OnDamageDealt;

    string _weaponName; // 디버깅을 위한 무기 이름 저장

    private void Awake()
    {
        _projectile = GetComponent<Projectile>();
        // 아마, 이렇게 하면 이름 못얻어올듯.
        _weaponName = GetComponentInParent<IWeapon>()?.Name ?? "Unknown"; // 부모 개체에서 이름 얻기
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

            OnDamageDealt?.Invoke(_weaponName, _damage, collision.name);
        }
    }
}