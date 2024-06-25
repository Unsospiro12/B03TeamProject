using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;          // ���� �̵� �ӵ�
    public float chaseRange = 5.0f;     // �÷��̾ �����ϱ� �����ϴ� �Ÿ�
    private Transform player;           // �÷��̾��� Transform
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection(); // �ʱ� ���� ����
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance < chaseRange)
        {
            direction.Normalize();
            movement = direction;
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    void ChangeDirection()
    {
        // ������ �������� ����
        float angle = Random.Range(0f, 360f);
        movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
