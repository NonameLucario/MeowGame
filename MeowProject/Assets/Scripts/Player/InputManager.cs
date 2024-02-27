using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private PlayerControls playerControls;
    private PlayerControls.InGameActions inGame;

    private PlayerMove move;

    private void Awake()
    {
        Instance = this;

        playerControls = new PlayerControls();
        inGame = playerControls.InGame;
        inGame.Enable();

        move = GetComponent<PlayerMove>();

        inGame.Jump.started += ctx => move.Jump();
    }

    private void Update()
    {
        move.ProcessMove(inGame.Move.ReadValue<Vector2>());
    }
}
