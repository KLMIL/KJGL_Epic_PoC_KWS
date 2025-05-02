/**********************************************************
 * Script Name: WeaponSalt
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어의 무기 중, 원거리 범위 공격 무기임 "Salt"
 *********************************************************/

using UnityEngine;

public class WeaponSalt : MonoBehaviour, IWeapon
{
    /* Interface status */
    public string Name => "Salt";
    public bool HasAmmo => true;
    public int Ammo => _ammo;

    int _ammo = 5; // 초기 잔탄수

    /* Attack status */
    [SerializeField] Transform _attackPoint;
    [SerializeField] GameObject _attackPrefab; // SaltAttack.prefab
    [SerializeField] float _attackRange = 0.3f; // 발사체 크기
    [SerializeField] int _damage = 5;

    public void Attack()
    {
        if (_ammo <= 0)
        {
            Debug.Log("No ammo");
            return;
        }
        _ammo--;

        GameObject attackInstance = Instantiate(_attackPrefab, _attackPoint.position, _attackPoint.rotation);
        attackInstance.transform.localScale = new Vector3(_attackRange, _attackRange, 1f);
        Projectile projectile = attackInstance.GetComponent<Projectile>();
        if (projectile != null)
        {
            Vector2 direction = transform.right;
            projectile.Initialize(direction);
            projectile.SetExplosionDamage(_damage);
        }

        Debug.Log("Salt: Sprinkling salt in a wide area");
    }
}
