using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameControls _gameControls;
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    private Vector2 _moveInput;
    private Rigidbody _rigidbody;
    private float _moveMultiplier = 40f;


    private void OnEnable()
    {
        _gameControls = new GameControls();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        
        _mainCamera = Camera.main;
        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name.CompareTo(_gameControls.PlayerControls.Movement.name) != 0)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }
    }

    private void Move()
    {
        var transform1 = _mainCamera.transform;
        _rigidbody.AddForce((transform1.forward * _moveInput.y +
                             transform1.right * _moveInput.x) *
                             _moveMultiplier * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
        
    }
}
