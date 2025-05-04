/**********************************************************
 * Script Name: ItemDrop
 * Author: 김우성
 * Date Created: 2025-05-04
 * Last Modified: 2025-05-04
 * Description: 
 * - 몬스터 사망 시 아이템 드롭 처리
 * - Health.onDeath 이벤트로 트리거
 *********************************************************/

using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] Item[] _possibleDrops; // 드롭 가능한 아이템 목록
    UILogManager _logManager;

    private void Awake()
    {
        _logManager = FindObjectOfType<UILogManager>();
        if (_logManager == null)
        {
            Debug.LogError("UILogManager not found in scene");
        }

        Health health = GetComponent<Health>();
        if (health != null) 
        {
            //health.OnDeath.AddListener(DropItem);
            health.OnDeathWithTopWeapon.AddListener(DropItem);
        }
        else
        {
            Debug.LogError($"{gameObject.name}: Health component not found");
        }
    }

    // 2025-05-04 KWS - DEPRECATED
    // 로직 수정을 위해 파라미터 변경 후 DEP
    //private void DropItem()
    //{
    //    // 드랍 아이템 로직 작성해야함.
    //    // 여기서 무기에 따라 다른 재료 드랍해야.
    //    foreach (Item item in _possibleDrops)
    //    {
    //        _logManager.AddLog($"Dropped {item.ItemName}");
    //    }
    //}

    private void DropItem(string topWeapon, float topDamage)
    {
        foreach (Item item in _possibleDrops)
        {
            if (string.IsNullOrEmpty(item.RequiredWeapon) || item.RequiredWeapon == topWeapon)
            {
                if (Random.value <= item.DropChance)
                {
                    // 아이템 인벤토리에 추가하는 함수 필요
                    _logManager?.AddLog($"Dropped {item.ItemName}");
                    //break; // 하나만 드랍할거면 break
                }
            }
        }
    }

    private void OnDestroy()
    {
        Health health = GetComponent<Health>();
        if (health != null)
        {
            //health.OnDeath.RemoveListener(DropItem);
            health.OnDeathWithTopWeapon.RemoveListener(DropItem);
        }
    }
}
