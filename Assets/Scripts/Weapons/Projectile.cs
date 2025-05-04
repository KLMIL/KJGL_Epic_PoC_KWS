/**********************************************************
 * Script Name: Projectile
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description: 
 * - 발사체 이동 및 수명 관리
 *********************************************************/

using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _lifeTime = 1f;
    [SerializeField] bool _explodeOnTimeout = false; // 시간 초과 시 폭발 여부
    [SerializeField] GameObject _explosionPrefab; // 폭발 시 프리펩
    [SerializeField] int _explosionDamage; // 폭발 시 대미지

    string _weaponName; // 2025-05-04 KWS - 추가 :: explosion에 전달할 무기 이름

    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized * _speed;
        Destroy(gameObject, _lifeTime);
    }

    private void OnDestroy()
    {
        if (_explodeOnTimeout && _explosionPrefab != null)
        {
            // 폭발 프리펩 생성
            GameObject explosionInstance = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Explosion explosion = explosionInstance.GetComponent<Explosion>();
            explosion.SetDamage(_explosionDamage);
            explosion.SetWeaponName(_weaponName);
        }
    }

    public void HitEnemy()
    {
        if (!_explodeOnTimeout)
        {
            Debug.Log("Enemy Hit!");
        }
    }

    public void SetExplosionDamage(int damage)
    {
        _explosionDamage = damage;
    }

    // 2025-05-04 KWS - 추가
    // 무기 이름도 전달
    public void SetWeaponName(string weaponName)
    {
        _weaponName = weaponName;
    }
}
