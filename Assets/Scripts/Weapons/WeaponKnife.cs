/**********************************************************
 * Script Name: WeaponKnife
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어의 무기 중, 근접 무기 "Knife"
 *********************************************************/

using UnityEngine;

public class WeaponKnife : MonoBehaviour, IWeapon
{
    /* Interface Status */
    public string Name => "Knife";
    public bool HasAmmo => false;
    public int Ammo => 0;

    /* Attack Status */
    [SerializeField] Transform _attackPoint;
    [SerializeField] GameObject _attackPrefab; // KnifeAttack.prefab
    [SerializeField] float _attackRangeX = 1f;
    [SerializeField] float _attackRangeY = 2f;
    [SerializeField] float _attackDuration = 0.2f;
    [SerializeField] int _damage = 10;


    public void Attack()
    {
        GameObject attackInstance = Instantiate(_attackPrefab, _attackPoint.position, _attackPoint.rotation);
        attackInstance.transform.localScale = new Vector3(_attackRangeX, _attackRangeY, 1f);
        AttackTrigger attackTrigger = attackInstance.GetComponent<AttackTrigger>();
        if (attackTrigger != null)
        {
            attackTrigger.SetDamage(_damage);
        }
        Destroy(attackInstance, _attackDuration);

        Debug.Log("Knife: Quick stab attack");
    }
}
