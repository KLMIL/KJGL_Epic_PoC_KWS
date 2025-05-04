/**********************************************************
 * Script Name: UILogManager
 * Author: 김우성
 * Date Created: 2025-05-04
 * Last Modified: 2025-05-04
 * Description: 
 * - 화면 우측에 로그를 표시하는 UI 관리 스크립트
 * - 몬스터 사망 시 아이템 획득 로그 추가
 *********************************************************/

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILogManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _logText;
    [SerializeField] int _maxLogLines = 10;
    List<string> _logs = new List<string>();


    private void Awake()
    {
        if (_logText == null)
        {
            Debug.LogError("Log TextMeshProUGUI is not assigned");
        }
    }

    public void AddLog(string message)
    {
        _logs.Add(message);
        if (_logs.Count > _maxLogLines)
        {
            _logs.RemoveAt(0);
        }
        UpdateLogDisplay();
    }


    private void UpdateLogDisplay()
    {
        _logText.text = string.Join("\n", _logs);
    }
}
