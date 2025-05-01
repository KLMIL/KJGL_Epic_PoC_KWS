/**********************************************************
 * Script Name: UIManager
 * Author: 김우성
 * Date Created: 2025-04-30
 * Last Modified: 2025-05-01
 * Description
 * - UI 상태 관리 역할
 * - 싱글턴
 *********************************************************/

using UnityEngine;

public class UIManager : MonoBehaviour
{
    /* Singleton instance */ 
    static UIManager _instance;
    public static UIManager Instance => _instance;

    /* Assign on inspector */
    [SerializeField] UIWeapon _uiWeapon;

    /* Assign on script */
    WeaponManager _weaponManager;


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


    public void Initialize(WeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
        UpdateWeaponUI(); // 초기 UI 업데이트
    }

    public void UpdateWeaponUI()
    {
        if (_weaponManager != null)
        {
            _uiWeapon.UpdateUI(_weaponManager.GetcurrentWeapon());
        }
    }
}
