using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Script : MonoBehaviour
{

    public float health = 100;
    public float speed = 2;
    public float damage = 2;
    public float attackCooldown = 2;

    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = new Vector3(1, 0, 0);
    }

    
    void Update()
    {
        
    }
}
