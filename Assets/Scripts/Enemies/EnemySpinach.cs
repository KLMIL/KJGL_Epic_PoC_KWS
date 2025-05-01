/**********************************************************
 * Script Name: EnmySpinach
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 식물 몬스터 중, 포자 공격을 하는 Spinach
 *********************************************************/

using EnemyAttack;
using UnityEngine;

public class EnemySpinach : EnemyBase
{
    [SerializeField] GameObject _sporePrefab; // 포자 프리펩

    [SerializeField] float _sporeSpeed = 5f; // 포자 속도
    [SerializeField] float _sporeDamage = 5f; // 포자 대미지
    [SerializeField] int _sporeCount = 8; // 한 번에 발사할 포자 수

    protected override void Attack()
    {
        if (playerTransform == null) return;

        Debug.Log($"Spawning {_sporeCount} spores from SpinachEenmy at {transform.position}");
        for (int i = 0; i < _sporeCount; i++)
        {
            // 적 개체를 중심으로 360도에 count만큼 방사형으로 발사
            float angle = i * (360f / _sporeCount);
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector2 spawnPos = (Vector2)transform.position;

            GameObject spore = Instantiate(_sporePrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

            // IEnemyAttack 인터페이스로 설정
            IEnemyAttack sporeAttack = spore.GetComponent<IEnemyAttack>();
            if (sporeAttack != null)
            {
                sporeAttack.SetProperties(_sporeDamage, direction, _sporeSpeed);
            }
            else
            {
                Debug.LogError("SporeAttack component missing on spore prefab");
            }
        }
    }
}
