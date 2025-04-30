/**********************************************************
 * Script Name: PlayerController
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - �÷��̾� ĳ������ ���۰� �Է� ó�� ���
 *********************************************************/

using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))] // PlayerInputHandler ������Ʈ�� �ʼ����� ���
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
        // �÷��̾� ������ �̺�Ʈ
        HandleMovement();
    }

    private void Update()
    {
        // �÷��̾� ���� �̺�Ʈ
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
            _inputHandler.ConsumeAttack(); // ���� �Է� �Һ�
        }
    }
}
