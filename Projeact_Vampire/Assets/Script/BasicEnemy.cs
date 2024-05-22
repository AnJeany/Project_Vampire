using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BasicEnemy : MonoBehaviour 
{
    [SerializeField] public Transform targetDestination;
    [SerializeField] private float speed;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask collisionLayer;//layer doi tuong muon ktr  
    GameObject targetGameObject;
    GameObject enemy;
    Rigidbody2D rb;

   
    private Vector2 direction;
    



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = enemyPosition.gameObject;
        targetGameObject = targetDestination.gameObject;
     
    }

    private void FixedUpdate()
    {
        if (targetDestination != null)
        {
            // Di chuyển kẻ địch về phía mục tiêu
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        CheckCollision();

    }

    public void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position,radius, direction, distance,collisionLayer);
        if (hit.collider != null)
        {
            Attack();
        }
        else
        {
            // Không có va chạm
            Debug.Log("Không có va chạm");
        }
    }
    void OnDrawGizmos()
    {
        // Vẽ vòng tròn tại vị trí hiện tại của đối tượng
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        // Vẽ đường di chuyển của CircleCast
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction * distance);
        Gizmos.DrawWireSphere(transform.position + (Vector3)direction * distance, radius);
    }

    private void Attack()
    {
        Debug.Log("Is attacking");
    }

}
