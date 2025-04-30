/**********************************************************
 * Script Name: GameManager
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 게임 시스템 전반의 흐름과 상태 관리
 * - 싱글턴
 *********************************************************/

using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* Singleton */
    static GameManager _instance;
    public static GameManager Instance => _instance;


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
}
