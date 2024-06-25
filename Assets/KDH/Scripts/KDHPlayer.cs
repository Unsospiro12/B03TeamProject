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
    SpriteRenderer spriter;
    public Animator anim;
    bool isXMove;

    public ObjScan objScan;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        x = objScan.isInteraction ? 0 : Input.GetAxisRaw("Horizontal");
        y = objScan.isInteraction ? 0 : Input.GetAxisRaw("Vertical");

        bool xDown = Input.GetButtonDown("Horizontal");
        bool xUp = Input.GetButtonUp("Horizontal");
        bool yUp = Input.GetButtonUp("Vertical");
        bool yDown = Input.GetButtonDown("Vertical");

        if (xDown)
            isXMove = true;
        else if (yDown)
            isXMove = false;
        else if (xUp || yUp)
            isXMove = x != 0;

        if (x == 1)
            dir = Vector3.right;
        else if(x == -1)
            dir = Vector3.left;
        
        if(y == 1)
            dir = Vector3.up;
        else if(y == -1)
            dir = Vector3.down;

        if (anim.GetInteger("x") != x)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("x", (int)x);
        }
        else if (anim.GetInteger("y") != y)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("y", (int)y);
        }
        else
            anim.SetBool("isChange", false);


        if (Input.GetMouseButtonDown(0) && rayObject != null)
            objScan.Scan(rayObject);
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = isXMove ? new Vector2(x, 0) : new Vector2(0, y);

        rb.velocity = moveVec * speed;

        RaycastHit2D rayScan = Physics2D.Raycast(rb.position, dir, 1f, LayerMask.GetMask("NPC"));

        if (rayScan.collider != null)
        {
            rayObject = rayScan.collider.gameObject;
        }
        else
            rayObject = null;

        if(x != 0)
        {
            spriter.flipX = x < 0;
        }
    }
}
