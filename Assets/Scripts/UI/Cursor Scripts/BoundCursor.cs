using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;

public class BoundCursor : MonoBehaviour
{
    private VirtualMouseInput vMouse;

    private float padding = 50;

    private void Awake()
    {
        vMouse = GetComponent<VirtualMouseInput>();
    }
    private void LateUpdate()
    {
        Vector2 vMousePos = vMouse.virtualMouse.position.value;
        vMousePos.x = Mathf.Clamp(vMousePos.x, padding, Screen.width - padding);
        vMousePos.y = Mathf.Clamp(vMousePos.y, padding, Screen.height - padding);
        InputState.Change(vMouse.virtualMouse.position, vMousePos);
    }
}
