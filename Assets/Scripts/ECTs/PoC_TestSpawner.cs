/**********************************************************
 * Script Name: PoC_TestSpawner
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - �⺻ Enemy ��ü ���� �׽�Ʈ�� ���� ��ũ��Ʈ
 *********************************************************/

using UnityEngine;
using Enums;

public class PoC_TestSpawner : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Spawning Enemy for testing");
        EnemyManager.Instance.SpawnEnemy(new Vector2(2, 0), EnemyType.Spinach);
    }
}
