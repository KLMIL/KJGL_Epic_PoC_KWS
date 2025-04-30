/**********************************************************
 * Script Name: PlayerController
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어 캐릭터의 동작과 입력 처리 담당
 *********************************************************/

using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))] // PlayerInputHandler 컴포넌트가 필수임을 명시
public class PlayerController : MonoBehaviour
{
    /* Components */ 
    PlayerInputHandler _inputHandler;
    Rigidbody2D _rb;

    /* Status */
    [Header("Movement")]
    [SerializeField] float _moveSpeed = 5f;


    private void Awake()
    {
        AssignComponents();
    }

    private void AssignComponents()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
        _rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        // 플레이어 움직임 이벤트
        HandleMovement();
    }

    private void Update()
    {
        // 플레이어 공격 이벤트
        HandleAttack();
    }

    private void HandleMovement()
    {
        Vector2 moveInput = _inputHandler.MoveInput;
        _rb.linearVelocity = moveInput.normalized * _moveSpeed;

        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void HandleAttack()
    {
        if (_inputHandler.AttackTriggered)
        {
            Debug.Log("Attack!");
            _inputHandler.ConsumeAttack(); // 공격 입력 소비
        }
    }
}
