using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController_KYJ : MonoBehaviour
{
    public Action inventory;

    private Vector2 moveDirection;
    private float moveSpeed = 4f;

    private void Update()
    {
        bool hasControl = (moveDirection != Vector2.zero);
        if (hasControl)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null )
        {
            moveDirection = new Vector3(input.x, input.y, 0f);
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
        }
    }
}
