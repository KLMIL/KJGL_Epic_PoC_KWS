/**********************************************************
 * Script Name: PoC_TestSpawner
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 기본 Enemy 개체 스폰 테스트를 위한 스크립트
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
