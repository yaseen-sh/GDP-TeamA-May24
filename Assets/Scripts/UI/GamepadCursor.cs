using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

// This should allow the user to select buttons with cursor using the gamepad left stick.

public class GamepadCursor : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private RectTransform cursorTransform;
    [SerializeField]
    private float cursorSpeed = 1000f;
    [SerializeField]
    private float padding = 50f;

    private Mouse virtualMouse;


    private Mouse currentMouse;
    private bool previousMouseState;

    private string previousControls = "";
    private const string gamepadControls = "Gamepad";
    private const string mouseControls = "Keyboard&Mouse";

    private void OnEnable()
    {
        currentMouse = Mouse.current;
        if (virtualMouse == null)
        {
            virtualMouse = (Mouse) InputSystem.AddDevice("VirtualMouse");
        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }
        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if (cursorTransform != null)
        {
            Vector2 pos = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, pos);
        }
        InputSystem.onAfterUpdate += UpdateMotion;
        playerInput.onControlsChanged += OnControlsChanged;
    }
    private void OnDisable()
    {
        //if (virtualMouse != null && virtualMouse.added) 
        InputSystem.RemoveDevice(virtualMouse);
        InputSystem.onAfterUpdate -= UpdateMotion;
        playerInput.onControlsChanged -= OnControlsChanged;
    }

    private void UpdateMotion()
    {
        if (virtualMouse == null || Gamepad.current == null) return;

        Vector2 stickValue = Gamepad.current.leftStick.ReadValue();
        stickValue *= cursorSpeed * Time.deltaTime;

        Vector2 curPos = virtualMouse.position.ReadValue();
        Vector2 newPos = curPos + stickValue;

        newPos.x = Mathf.Clamp(newPos.x, padding, Screen.width - padding);
        newPos.y = Mathf.Clamp(newPos.y, padding, Screen.height - padding);

        InputState.Change(virtualMouse.position, newPos);
        InputState.Change(virtualMouse.delta, stickValue);


        bool aButtonPressed = Gamepad.current.aButton.IsPressed();

        if (previousMouseState != aButtonPressed)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonPressed);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = aButtonPressed;
        }
    }
    private void OnControlsChanged(PlayerInput input)
    {
        if (playerInput.currentControlScheme == mouseControls && previousControls != mouseControls)
        {
            cursorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());
            previousControls = mouseControls;
        }
        else if (playerInput.currentControlScheme == gamepadControls && previousControls != gamepadControls)
        {
            cursorTransform.gameObject.SetActive(true);
            Cursor.visible = false;
            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());

            previousControls = mouseControls;
        }
    }
}
