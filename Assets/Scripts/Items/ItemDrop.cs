/**********************************************************
 * Script Name: ItemDrop
 * Author: ��켺
 * Date Created: 2025-05-04
 * Last Modified: 2025-05-04
 * Description: 
 * - ���� ��� �� ������ ��� ó��
 * - Health.onDeath �̺�Ʈ�� Ʈ����
 *********************************************************/

using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] Item[] _possibleDrops; // ��� ������ ������ ���
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
    // ���� ������ ���� �Ķ���� ���� �� DEP
    //private void DropItem()
    //{
    //    // ��� ������ ���� �ۼ��ؾ���.
    //    // ���⼭ ���⿡ ���� �ٸ� ��� ����ؾ�.
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
                if (Random.value <= item.DropChange)
                {
                    // ������ �κ��丮�� �߰��ϴ� �Լ� �ʿ�
                    _logManager?.AddLog($"Dropped {item.ItemName}");
                    //break; // �ϳ��� ����ҰŸ� break
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
