using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_KYJ : MonoBehaviour
{
    public PlayerController_KYJ controller;

    private void Awake()
    {
        CharacterManager_KYJ.Instance.Player = this;
        controller = GetComponent<PlayerController_KYJ>();
    }
}
