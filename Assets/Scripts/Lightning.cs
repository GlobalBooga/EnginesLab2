using System.Collections;
using UnityEngine;

public class Lightning : Projectile
{
    public LayerMask ignoreLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Launch(Vector2 directionNormalized)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, directionNormalized, 1000,ignoreLayer );

        lineRenderer.SetPosition(0, gameObject.transform.position);
        if (hit.collider) lineRenderer.SetPosition(1, hit.point);
        else lineRenderer.SetPosition(1, gameObject.transform.position + new Vector3(directionNormalized.x, directionNormalized.y,0) * 200);
        Destroy(gameObject, 0.5f);
    }

}
