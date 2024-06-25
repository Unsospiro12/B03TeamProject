using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_KYJ : MonoBehaviour
{
    public PlayerController_KYJ controller;

    public ItemData itemData;
    public Action addItem;
    public ObjScan objScan;

    float x;
    float y;
    public float speed;

    GameObject rayObject;

    Rigidbody2D rb;

    Vector3 dir;

    private void Awake()
    {
        CharacterManager_KYJ.Instance.Player = this;
        controller = GetComponent<PlayerController_KYJ>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = objScan.isInteraction ? 0 : Input.GetAxisRaw("Horizontal");
        y = objScan.isInteraction ? 0 : Input.GetAxisRaw("Vertical");

        if (x == 1)
            dir = Vector3.right;
        else if (x == -1)
            dir = Vector3.left;

        if (y == 1)
            dir = Vector3.up;
        else if (y == -1)
            dir = Vector3.down;

        if (Input.GetMouseButtonDown(0) && rayObject != null)
            objScan.Scan(rayObject);
    }

    private void FixedUpdate()
    {
        RaycastHit2D rayScan = Physics2D.Raycast(rb.position, dir, 1f, LayerMask.GetMask("NPC"));

        if (rayScan.collider != null)
        {
            rayObject = rayScan.collider.gameObject;
        }
        else
            rayObject = null;
    }
}
