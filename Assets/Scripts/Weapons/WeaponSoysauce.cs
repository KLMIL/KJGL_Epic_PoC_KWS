/**********************************************************
 * Script Name: WeaponSoysauce
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
 * Description
 * - 플레이어의 무기 중, 원거리 단일 공격 무기인 "Soysauce"
 *********************************************************/

using UnityEngine;

public class WeaponSoysauce : MonoBehaviour, IWeapon
{
    /* Interface Status */
    public string Name => "Soysauce";
    public bool HasAmmo => true;
    public int Ammo => _ammo;

    int _ammo = 10; // 초기 잔탄수

    /* Attack Status */
    [SerializeField] Transform _attackPoint;
    [SerializeField] GameObject _attackPrefab; // SoysauceAttack.prefab
    [SerializeField] float _attackRange = 0.5f; // 발사체 크기
    [SerializeField] int _damage = 8;


    public void Attack()
    {
        if (_ammo <= 0)
        {
            Debug.Log("No ammo!");
            return;
        }
        _ammo--;

        GameObject attackInstance = Instantiate(_attackPrefab, _attackPoint.position, _attackPoint.rotation);
        attackInstance.transform.localScale = new Vector3(_attackRange, _attackRange, 1f);
        AttackTrigger attackTrigger = attackInstance.GetComponent<AttackTrigger>();
        if (attackTrigger != null)
        {
            attackTrigger.SetDamage(_damage);
            // 2025-05-04 KWS - 추가
            // attackTrigger에 무기 이름 전달
            attackTrigger.SetWeaponName(Name);
        }
        Projectile projectile = attackInstance.GetComponent<Projectile>();
        if (projectile != null)
        {
            Vector2 direction = transform.right;
            projectile.Initialize(direction);
        }

        Debug.Log("Soysauce: Throwing a soysauce");
    }
}
