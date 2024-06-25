using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.0f;     // ���� ����
    public int damage = 10;              // ���ݷ�
    public float attackCooldown = 2.0f;  // ���� ����

    private Transform player;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastAttackTime = -attackCooldown;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        // ���⼭ �÷��̾��� ü�� �ý����� ã�� ü�� ���Ҹ� ȣ���մϴ�.
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
