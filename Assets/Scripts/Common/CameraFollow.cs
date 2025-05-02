/**********************************************************
 * Script Name: CameraFollow
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 메인 카메라가 플레이어를 부드럽게 따라다님
 *********************************************************/

using Mono.Cecil.Cil;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _playerTransform; // 따라다닐 Player Transform
    [SerializeField] Vector3 _offset = new Vector3(0, 0, -10); // 카메라 오프셋
    [SerializeField] float _smoothSpeed = 0.125f; // 부드러운 이동 속도. 낮을수록 부드러움
    [SerializeField] bool _useSmoothing = true; // 부드러운 이동 활성화


    private void FixedUpdate()
    {
        if (_playerTransform == null)
        {
            Debug.LogWarning("CameraFollow: Target not assigned");
            return;
        }

        // 목표 위치: 플레이어 위치 + 오프셋
        Vector3 desiredPosition = _playerTransform.position + _offset;

        // 부드러운 이동
        if (_useSmoothing)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = desiredPosition;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        _playerTransform = newTarget;
    }
}
