using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    public GameObject GetProjectilePrefab => projectilePrefab;
}
