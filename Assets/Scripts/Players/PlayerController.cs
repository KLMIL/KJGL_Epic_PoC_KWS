/**********************************************************
 * Script Name: PlayerController
 * Author: 김우성
 * Date Created: 2025-04-30
 * Last Modified: 2025-05-01
 * Description
 * - 플레이어 캐릭터의 동작과 입력 처리 담당
 *********************************************************/

using UnityEngine;

// RequireComponent: 해당 컴포넌트가 필수임을 명시. 없다면 자동 추가
[RequireComponent(typeof(PlayerInputHandler))] 
[RequireComponent(typeof(WeaponManager))]
public class PlayerController : MonoBehaviour
{
    /* Components */ 
    PlayerInputHandler _inputHandler;
    WeaponManager _weaponManager;
    Rigidbody2D _rb;

    UIManager _uiManager;
    

    /* Status */
    [Header("Movement")]
    [SerializeField] float _moveSpeed = 5f;


    private void Awake()
    {
        AssignComponents();
    }

    private void Start()
    {
        InitializeUIManager();
    }

    private void AssignComponents()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
        _weaponManager = GetComponent<WeaponManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void InitializeUIManager()
    {
        _uiManager = UIManager.Instance;
        if (_uiManager != null)
        {
            Debug.Log("UI Manager Initialization");
            _uiManager.Initialize(_weaponManager);
        }
    }


    private void FixedUpdate()
    {
        // 플레이어 움직임 이벤트
        HandleMovement();
    }

    private void Update()
    {
        // 플레이어 공격 이벤트 -> WeaponManager 구현을 위해 우선 제외
        HandleAttack();
        HandleWeaponSwitch();
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
            _weaponManager.Attack();
            _inputHandler.ConsumeAttack(); // 공격 입력 소비
        }
    }

    private void HandleWeaponSwitch()
    {
        if (_inputHandler.WeaponSlot1Triggered)
        {
            _weaponManager.SwitchWeapon(0);
            _uiManager?.UpdateWeaponUI();
            _inputHandler.ConsumeWeaponSlot1();
        }
        else if (_inputHandler.WeaponSlot2Triggered) 
        {
            _weaponManager.SwitchWeapon(1);
            _uiManager?.UpdateWeaponUI();
            _inputHandler.ConsumeWeaponSlot2();
        }
        else if ( _inputHandler.WeaponSlot3Triggered)
        {
            _weaponManager.SwitchWeapon(2);
            _uiManager?.UpdateWeaponUI();
            _inputHandler.ConsumeWeaponSlot3();
        }
        else
        {
            /* Do Nothing */
        }
    }
}
