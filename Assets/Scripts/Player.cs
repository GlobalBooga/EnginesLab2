using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputSystem_Actions _actions;

    private Vector2 _rawInput;
    private Vector2 _mousePos;
    public float speed = 10f;
    
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    private Rigidbody2D _rigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _actions = new InputSystem_Actions();
        _actions.Player.Move.Enable();
        _actions.Player.Move.performed += context =>
        {
            _rawInput = context.ReadValue<Vector2>();
            _rawInput.y = 0;
        };
        _actions.Player.Move.canceled += context =>
        {
            _rawInput = context.ReadValue<Vector2>();
            _rawInput.y = 0;
        };
        
        _actions.Player.MousePos.Enable();
        _actions.Player.MousePos.performed += context =>
        {
            _mousePos = context.ReadValue<Vector2>();
            Vector2 mouseDirectionPlayer = (gameObject.transform.position - Camera.main.ScreenToWorldPoint(_mousePos));
            gameObject.transform.right = mouseDirectionPlayer.x > 0? Vector3.right : Vector3.left;
            
        };
        
        _actions.Player.Attack.Enable();
        _actions.Player.Attack.performed += context =>
        {
            if (projectilePrefab)
            {
                Vector2 directionNormalized = Camera.main.ScreenToWorldPoint(_mousePos) - projectileSpawn.position;
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, Quaternion.LookRotation(Vector3.forward, directionNormalized));
                projectile.GetComponent<Projectile>().Launch(directionNormalized.normalized);
            }
        };
    }

    private void OnDestroy()
    {
        _actions.Dispose();
    }

    // Update is called once per frame
    private void Update()
    {
        _rigidbody2D.linearVelocity = _rawInput.normalized * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Selector selector))
        {
            projectilePrefab = selector.GetProjectilePrefab;
        }
    }
}
