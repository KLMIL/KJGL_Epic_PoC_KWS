/**********************************************************
 * Script Name: TEST_EnemySpawner
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
 * Description: 
 * - 기본 Enemy 개체 스폰 테스트를 위한 스크립트
 * - 버튼 클릭 시 지정된 위치에 몬스터 스폰
 *********************************************************/

using UnityEngine;
using Enums;
using UnityEngine.UI;

public class TEST_EnemySpawner : MonoBehaviour
{
    [SerializeField] Button _potatoSpawnButton;
    [SerializeField] Button _spinachSpawnButton;
    [SerializeField] Vector2 _spawnPosition = new Vector2(2, 0);

    GameObject _currSpawnedEnemy;

    private void Start()
    {
        if (_potatoSpawnButton != null && _spinachSpawnButton != null)
        {
            _potatoSpawnButton.onClick.AddListener(SpawnPotato);
            _spinachSpawnButton.onClick.AddListener(SpawnSpinach);
        }
        else
        {
            Debug.LogWarning("Spawn button not assigned");
        }
    }

    private void SpawnPotato()
    {
        EnemyManager.Instance.SpawnEnemy(_spawnPosition, EnemyType.Potato);
    }

    private void SpawnSpinach()
    {
        EnemyManager.Instance.SpawnEnemy(_spawnPosition, EnemyType.Spinach);
    }


    private void OnDestroy()
    {
        if (_spinachSpawnButton != null && _potatoSpawnButton != null)
        {
            _potatoSpawnButton.onClick.RemoveListener(SpawnPotato);
            _spinachSpawnButton.onClick.RemoveListener(SpawnSpinach);
        }
    }
}
