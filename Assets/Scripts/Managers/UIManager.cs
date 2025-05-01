/**********************************************************
 * Script Name: UIManager
 * Author: 김우성
 * Date Created: 2025-04-30
 * Last Modified: 0000-00-00
 * Description
 * - UI 상태 관리 역할
 * - 싱글턴
 *********************************************************/

using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance => _instance;


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
