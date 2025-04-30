/**********************************************************
 * Script Name: UIManager
 * Author: 辫快己
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - UI 惑怕 包府 开且
 * - 教臂畔
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
