using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Script : MonoBehaviour
{

    public float health = 100;
    public float speed ;
    public float damage;
    public float attackCooldown;

    private Vector3 _direction;
    
    void Start()
    {
        _direction = new Vector3(0, -1 * speed * Time.deltaTime, 0);
    }

    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.position += _direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Turn 1" || collision.gameObject.name == "Turn 3")
        {
            _direction = new Vector3(1 * speed * Time.deltaTime, 0, 0);
        }

        if (collision.gameObject.name == "Turn 2" || collision.gameObject.name == "Turn 6")
        {
            _direction = new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }

        if (collision.gameObject.name == "Turn 4")
        {
            _direction = new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }

        if (collision.gameObject.name == "Turn 5")
        {
            _direction = new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        }
    }
}
