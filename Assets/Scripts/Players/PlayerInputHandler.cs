/**********************************************************
 * Script Name: PlayerInputHandler
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - �÷��̾��� �Է� ó�� �� 
 *   �ش��ϴ� �׼� ȣ���Ͽ� �÷��̾� ���� ��������
 *********************************************************/

using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    InputActions _inputActions;

    public Vector2 MoveInput { get; private set; }
    public bool AttackTriggered { get; private set; }


    private void Awake()
    {
        _inputActions = new InputActions();

        // �̵� �Է� �̺�Ʈ ����
        _inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += _ => MoveInput = Vector2.zero;

        // ���� �Է� �̺�Ʈ ����
        _inputActions.Player.Attack.performed += _ => AttackTriggered = true;
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void OnDestroy()
    {
        // �̺�Ʈ ����
        _inputActions.Player.Move.performed -= ctx => MoveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled -= _ => MoveInput = Vector2.zero;
        _inputActions.Player.Attack.performed -= _ => AttackTriggered = true;
    }


    // �÷��̾� ���� �Ϸ�� ���°� ����
    public void ConsumeAttack() => AttackTriggered = false;
}
