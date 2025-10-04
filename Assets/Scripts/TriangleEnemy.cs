using UnityEngine;

public class TriangleEnemy : Enemy
{

    public int spawnQty = 2;
    public GameObject circleEnemyPrefab;
    
    public override void OnHit()
    {
        if (circleEnemyPrefab)
        {
            for (int i = 0; i < spawnQty; i++)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-3, 3), Random.Range(1, 5), 0);
                Instantiate(circleEnemyPrefab, transform.position + randomOffset, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }

   
}
