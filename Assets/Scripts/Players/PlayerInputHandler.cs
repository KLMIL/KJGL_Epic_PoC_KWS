/**********************************************************
 * Script Name: PlayerInputHandler
 * Author: 김우성
 * Date Created: 2025-04-30
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
    public bool WeaponSlot1Triggered { get; private set; }
    public bool WeaponSlot2Triggered { get; private set; }
    public bool WeaponSlot3Triggered { get; private set; }


    private void Awake()
    {
        _inputActions = new InputActions();

        // 이동 입력 이벤트 연결
        _inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += _ => MoveInput = Vector2.zero;

        // 공격 입력 이벤트 연결
        _inputActions.Player.Attack.performed += _ => AttackTriggered = true;

        // 무기 전환 입력 이벤트 연결
        _inputActions.Player.WeaponSlot1.performed += _ => WeaponSlot1Triggered = true;
        _inputActions.Player.WeaponSlot2.performed += _ => WeaponSlot2Triggered = true;
        _inputActions.Player.WeaponSlot3.performed += _ => WeaponSlot3Triggered = true;
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void OnDestroy()
    {
        // 이벤트 해제
        _inputActions.Player.Move.performed -= ctx => MoveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled -= _ => MoveInput = Vector2.zero;
        _inputActions.Player.Attack.performed -= _ => AttackTriggered = true;
        _inputActions.Player.WeaponSlot1.performed -= _ => WeaponSlot1Triggered = true;
        _inputActions.Player.WeaponSlot2.performed -= _ => WeaponSlot2Triggered = true;
        _inputActions.Player.WeaponSlot3.performed -= _ => WeaponSlot3Triggered = true;
    }


    // 입력 소비 메서드 -> 입력 동작 수행 후 상태 초기화
    public void ConsumeAttack() => AttackTriggered = false;
    public void ConsumeWeaponSlot1() => WeaponSlot1Triggered = false;
    public void ConsumeWeaponSlot2() => WeaponSlot2Triggered = false;
    public void ConsumeWeaponSlot3() => WeaponSlot3Triggered = false;
}
