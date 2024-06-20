using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_KYJ : MonoBehaviour
{
    public Action inventory;

    void Start()
    {

    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
        }
    }
}
