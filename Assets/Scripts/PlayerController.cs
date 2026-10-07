using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(WallrunController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [Header("Input Variables")]
    [SerializeField] private Vector2 _moveInput;

    [Header("Actions")]
    [SerializeField] private InputAction _moveAction;

    [Header("Ground Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _gndControlMod;
    [SerializeField] private float _jumpForce;

    [Header("Air Settings")]
    [SerializeField] private float _airMoveSpeed;
    [SerializeField] private float _airAcceleration;
    [SerializeField] private float _airControlMod;
    [SerializeField] private float _airJumpForce;

    [Header("Extra Components")]
    [SerializeField] private WallrunController _wallRunning;

    [Header("References")]
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody _rb;

    void Start()
    {
        // Get references
        TryGetComponent<PlayerInput>(out _input);
        TryGetComponent<Rigidbody>(out _rb);
        TryGetComponent<WallrunController>(out _wallRunning);

        // Set up actions
        _moveAction = _input.actions.FindAction("Move", true);
        _moveAction.performed += context => Jump();
    }

    private void Update()
    {
        HandleConstantInput();
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeForce(_moveInput * _moveSpeed);
    }

    private void HandleConstantInput()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce);
    }
}