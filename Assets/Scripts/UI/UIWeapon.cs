/**********************************************************
 * Script Name: UIWeapon
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 장착 중인 무기와 잔탄량 등을 표기하는 UI
 *********************************************************/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    [SerializeField] Image _slotBackground; // 직사각형 슬롯 배경
    [SerializeField] Image _weaponIcon; // 정사각형 아이콘
    [SerializeField] TextMeshProUGUI _weaponNameText; // 무기 이름 텍스트
    [SerializeField] TextMeshProUGUI _ammoText; // 잔탄수 텍스트

    public void UpdateUI(IWeapon weapon)
    {
        if (weapon == null) return;

        // 무기 이름 업데이트
        _weaponNameText.text = weapon.Name;

        // 잔탄수 업데이트
        _ammoText.text = weapon.HasAmmo ? $"Ammo: {weapon.Ammo}" : "";

        // 무기 아이콘 업데이트 -> 색상으로 임시 구분
        _weaponIcon.color = PoC_GetWeaponColor(weapon.Name);
    }

    private Color PoC_GetWeaponColor(string weaponName)
    {
        switch (weaponName)
        {
            case "Knife": return Color.red;
            case "Soysauce": return Color.yellow;
            case "Salt": return Color.white;
            default: return Color.gray;
        }
    }
}
