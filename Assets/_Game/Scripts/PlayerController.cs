using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Rigidbody2D rb;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();

        inputActions.PlayerControls.Attack.performed += OnAttackInput;
    }

    private void OnAttackInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack pressed!");
    }

    private void Update()
    {
        Vector2 moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed * Time.deltaTime;
    }
}
