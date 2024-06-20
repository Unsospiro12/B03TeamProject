using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDHPlayer : MonoBehaviour
{
    float x;
    float y;
    public float speed;
    Vector3 dir;
    Rigidbody2D rb;
    GameObject rayObject;

    public ObjScan objScan;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = objScan.isInteraction ? 0 : Input.GetAxisRaw("Horizontal");
        y = objScan.isInteraction ? 0 : Input.GetAxisRaw("Vertical");

        if (x == 1)
            dir = Vector3.right;
        else if(x == -1)
            dir = Vector3.left;
        
        if(y == 1)
            dir = Vector3.up;
        else if(y == -1)
            dir = Vector3.down;

        if (Input.GetMouseButtonDown(0) && rayObject != null)
            objScan.Scan(rayObject);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (x, y) * speed;

        RaycastHit2D rayScan = Physics2D.Raycast(rb.position, dir, 1f, LayerMask.GetMask("NPC"));

        if (rayScan.collider != null)
        {
            rayObject = rayScan.collider.gameObject;
        }
        else
            rayObject = null;
    }
}
