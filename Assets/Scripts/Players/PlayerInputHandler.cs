/**********************************************************
 * Script Name: PlayerInputHandler
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description
 * - 플레이어의 입력 처리 및 
 *   해당하는 액션 호출하여 플레이어 상태 업데이터
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

        // 이동 입력 이벤트 연결
        _inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += _ => MoveInput = Vector2.zero;

        // 공격 입력 이벤트 연결
        _inputActions.Player.Attack.performed += _ => AttackTriggered = true;
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void OnDestroy()
    {
        // 이벤트 해제
        _inputActions.Player.Move.performed -= ctx => MoveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled -= _ => MoveInput = Vector2.zero;
        _inputActions.Player.Attack.performed -= _ => AttackTriggered = true;
    }


    // 플레이어 공격 완료시 상태값 변경
    public void ConsumeAttack() => AttackTriggered = false;
}
