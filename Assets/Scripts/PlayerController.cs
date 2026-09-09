using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(WallrunController), typeof(PlayerInputManager))]
public class PlayerController : MonoBehaviour
{
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
    [SerializeField] private PlayerInputManager _input;
    [SerializeField] private Rigidbody _rb;

    void Start()
    {
        TryGetComponent<PlayerInputManager>(out _input);
        TryGetComponent<Rigidbody>(out _rb);
        TryGetComponent<WallrunController>(out _wallRunning);
    }

    void Update()
    {
        
    }
}