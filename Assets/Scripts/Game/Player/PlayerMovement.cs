

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _screenBorder;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateTowardsMouse();
        UpdateAnimator();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);
        _rigidbody2D.velocity = _smoothedMovementInput * _speed;
        PreventPlayerGoingOffTheScreen();
    }

    private void PreventPlayerGoingOffTheScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < _screenBorder && _rigidbody2D.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && _rigidbody2D.velocity.x > 0))
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }

        if ((screenPosition.y < _screenBorder && _rigidbody2D.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - _screenBorder && _rigidbody2D.velocity.y > 0))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;

        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Quay sang phải
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Quay sang trái
        }
    }

    private void UpdateAnimator()
    {
        bool isRunning = _movementInput != Vector2.zero;
        _animator.SetBool("running", isRunning);
    }

    public Vector2 GetMovementInput()
    {
        return _movementInput;
    }
}
