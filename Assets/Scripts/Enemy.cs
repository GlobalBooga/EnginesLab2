using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    protected Rigidbody2D rb;
    
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void OnHit()
    {
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        Vector2 direction = playerTransform.position - transform.position;
        rb.AddForce(direction.normalized * speed);
        rb.linearVelocity = new Vector2(Math.Clamp(rb.linearVelocity.x, 0, speed), rb.linearVelocity.y);
    }
}
