/**********************************************************
 * Script Name: EnemyManager
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - ��� �� ��ü�� �����ϰ�, ���� ���� �� ���� ó��
 *********************************************************/

using UnityEngine;
using System.Collections.Generic;
using Enums;

public class EnemyManager : MonoBehaviour
{
    /* Singleton instance */
    static EnemyManager _instance;
    public static EnemyManager Instance => _instance;


    [SerializeField] GameObject PoC_potatoPrefab; // ���� ���� ������
    [SerializeField] GameObject PoC_spinachPrefab; // �ñ�ġ ���� ������

    List<EnemyBase> activeEnemies = new List<EnemyBase>();


    private void Awake()
    {
        MakeSingleton();   
    }

    private void MakeSingleton()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }


    public void SpawnEnemy(Vector3 position, EnemyType enemyType)
    {
        GameObject enemyPrefab = null;
        switch (enemyType)
        {
            case EnemyType.Potato:
                enemyPrefab = PoC_potatoPrefab;
                break;
            case EnemyType.Spinach:
                enemyPrefab = PoC_spinachPrefab;
                break;
            default:
                break;
        }

        GameObject enemyObj = Instantiate(enemyPrefab, position, Quaternion.identity);
        EnemyBase enemy = enemyObj.GetComponent<EnemyBase>();
        activeEnemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        activeEnemies.Remove(enemy);
    }

    public void ClearAllEnemies()
    {
        foreach (var enemy in activeEnemies)
        {
            Destroy(enemy.gameObject);
        }
        activeEnemies.Clear();
    }
}
