using UnityEngine;

public class Projectile : MonoBehaviour
{
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Launch(Vector2 directionNormalized)
    {
        GetComponent<Rigidbody2D>().AddForce(directionNormalized * 10, ForceMode2D.Impulse);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
