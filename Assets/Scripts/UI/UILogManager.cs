/**********************************************************
 * Script Name: UILogManager
 * Author: ��켺
 * Date Created: 2025-05-04
 * Last Modified: 2025-05-04
 * Description: 
 * - ȭ�� ������ �α׸� ǥ���ϴ� UI ���� ��ũ��Ʈ
 * - ���� ��� �� ������ ȹ�� �α� �߰�
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
