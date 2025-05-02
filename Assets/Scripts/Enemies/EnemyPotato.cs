/**********************************************************
 * Script Name: EnemyPotato
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 식물 몬스터 중, 뿌리 공격을 하는 Potato
 *********************************************************/

using EnemyAttack;
using UnityEngine;

public class EnemyPotato : EnemyBase
{
    [SerializeField] GameObject _rootPrefab; // 뿌리 공격 프리펩
    [SerializeField] float _rootSpawnOffset = 0.5f; // 뿌리 스폰 위치 프리셋
    [SerializeField] float _rootDamage = 10f; // 뿌리 공격 대미지

    protected override void Attack()
    {
        if (playerTransform == null) return;

        // 플레이어 위치 아래에 뿌리 스폰
        Vector2 spawnPos = (Vector2)playerTransform.position + Vector2.down * _rootSpawnOffset;

        // Instantiate는 Vector3를 요구하므로, z = 0으로 변환
        GameObject root = Instantiate(_rootPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

        // IEnemyAttack 인터페이스로 설정
        IEnemyAttack rootAttack = root.GetComponent<IEnemyAttack>();
        if (rootAttack != null)
        {
            rootAttack.SetProperties(_rootDamage);
        }
        else
        {
            Debug.LogError("RootAttack component missing on root prefab");
        }
    }
}
