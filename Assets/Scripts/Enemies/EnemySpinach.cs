/**********************************************************
 * Script Name: EnmySpinach
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - �Ĺ� ���� ��, ���� ������ �ϴ� Spinach
 *********************************************************/

using EnemyAttack;
using UnityEngine;

public class EnemySpinach : EnemyBase
{
    [SerializeField] GameObject _sporePrefab; // ���� ������

    [SerializeField] float _sporeSpeed = 5f; // ���� �ӵ�
    [SerializeField] float _sporeDamage = 5f; // ���� �����
    [SerializeField] int _sporeCount = 8; // �� ���� �߻��� ���� ��

    protected override void Attack()
    {
        if (playerTransform == null) return;

        Debug.Log($"Spawning {_sporeCount} spores from SpinachEenmy at {transform.position}");
        for (int i = 0; i < _sporeCount; i++)
        {
            // �� ��ü�� �߽����� 360���� count��ŭ ��������� �߻�
            float angle = i * (360f / _sporeCount);
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector2 spawnPos = (Vector2)transform.position;

            GameObject spore = Instantiate(_sporePrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);

            // IEnemyAttack �������̽��� ����
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
