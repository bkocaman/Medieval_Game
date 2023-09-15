using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public GameObject firstWeapon;
    public GameObject secondWeapon;
    public bool IsAttacking { get; private set; }
    public bool IsBlocking { get; private set; }
    public Vector2 MovementValue { get; private set; }
    public event Action DodgeEvent;
    public event Action JumpEvent;
    public event Action TargetingEvent;
    public event Action WeaponChange;
    public event Action AbilityEvent;
    private Controls controls;
    private DashAbility dashAbility1;


    private void Awake()
    {
        dashAbility1 = GetComponent<DashAbility>();
    }
    private void Start()
    {
        //firstWeapon.SetActive(true);
        //secondWeapon.SetActive(false);
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            JumpEvent?.Invoke();
        }

    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DodgeEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {

    }

    public void OnTargeting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TargetingEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsAttacking = true;
        }
        else if (context.canceled)
        {
            IsAttacking = false;
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsBlocking = true;
        }
        else if (context.canceled)
        {
            IsBlocking = false;
        }
    }
    public void OnWeaponChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            WeaponChange?.Invoke();
            bool isFirstWeaponActive = firstWeapon.activeSelf;
            firstWeapon.SetActive(!isFirstWeaponActive);
            secondWeapon.SetActive(isFirstWeaponActive);
        }
    }
    public void OnAbility1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (dashAbility1 != null)
            {
                AbilityEvent?.Invoke();
                dashAbility1.TriggerAbility();
            }
            else
            {
                Debug.LogError("dashAbility is not assigned!");
            }
        }
    }

}