using UnityEngine;

public class CircleEnemy : Enemy
{
    public int hp = 3;
    public float jumpForce = 5f;
    
    public override void OnHit()
    {
        if (--hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
}
