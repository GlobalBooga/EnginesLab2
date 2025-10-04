using System;
using UnityEngine;

public class Dart : Projectile
{
    public float speed = 20f;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Launch(Vector2 directionNormalized)
    {
        GetComponent<Rigidbody2D>().AddForce(directionNormalized * speed, ForceMode2D.Impulse);
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Dart collision");
        Destroy(gameObject);
    }
}
