using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    private PlayerInput input;
    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed;
    }
}//https://www.youtube.com/watch?v=IurqiqduMVQ
