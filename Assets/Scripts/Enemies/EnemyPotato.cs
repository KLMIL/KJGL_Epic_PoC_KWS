/**********************************************************
 * Script Name: EnemyPotato
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - �Ĺ� ���� ��, �Ѹ� ������ �ϴ� Potato
 *********************************************************/

using EnemyAttack;
using UnityEngine;

public class EnemyPotato : EnemyBase
{
    [SerializeField] GameObject _rootPrefab; // �Ѹ� ���� ������
    [SerializeField] float _rootSpawnOffset = 0.5f; // �Ѹ� ���� ��ġ ������
    [SerializeField] float _rootDamage = 10f; // �Ѹ� ���� �����

    protected override void Attack()
    {
        if (playerTransform == null) return;

        // �÷��̾� ��ġ �Ʒ��� �Ѹ� ����
        Vector2 spawnPos = (Vector2)playerTransform.position + Vector2.down * _rootSpawnOffset;

        // Instantiate�� Vector3�� �䱸�ϹǷ�, z = 0���� ��ȯ
        GameObject root = Instantiate(_rootPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

        // IEnemyAttack �������̽��� ����
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
