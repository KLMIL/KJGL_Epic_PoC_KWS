/**********************************************************
 * Script Name: DebugLogUI
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 디버깅용 데미지 로그를 Canvas Panel에 표시
 *********************************************************/

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugLog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _logText; // 로그 표시용 TextMeshProUGUI
    [SerializeField] RectTransform _contentRect; // ScrollView의 Content
    [SerializeField] int _maxLogs = 1000; // 최대 로그 수
    [SerializeField] float _lineHeight = 20f; // 로그 한 줄 높이

    List<string> _logs = new List<string>();


    private void Awake()
    {
        if (_logText == null)
        {
            Debug.LogError("LogText not assigned in UIDebugLog");
        }
        if (_contentRect == null)
        {
            Debug.LogError("ContentRect not assigned in UIDebugLog");
        }
    }

    private void OnEnable()
    {
        AttackTrigger.OnDamageDealt += AddDamageLog;
    }

    private void OnDisable()
    {
        AttackTrigger.OnDamageDealt -= AddDamageLog;
    }

    public void AddDamageLog(string weaponName, int damage, string enemyName)
    {
        string log = $"[{System.DateTime.Now:HH:mm:ss}] {weaponName} hit {enemyName} for {damage} damage";
        _logs.Add(log);
        if (_logs.Count > _maxLogs)
        {
            _logs.RemoveAt(0);
        }
        UpdateLogText();
    }

    private void UpdateLogText()
    {
        _logText.text = string.Join("\n", _logs);
        _contentRect.sizeDelta = new Vector2(_contentRect.sizeDelta.x, _logs.Count * _lineHeight);
        Canvas.ForceUpdateCanvases(); // 스크롤 갱신
        ScrollRect scrollRect = _contentRect.GetComponentInParent<ScrollRect>();
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}
