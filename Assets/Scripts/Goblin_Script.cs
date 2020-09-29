using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Script : MonoBehaviour
{

    public float health = 100;
    public float speed = 2;
    public float damage = 2;
    public float attackCooldown = 2;
    public GameObject bloodSplatter;

    private Vector3 _direction;
    
    void Start()
    {
        _direction = new Vector3(0, -1 * speed * Time.deltaTime, 0);
    }

    
    void Update()
    {
        if (health <= 0)
        {
            //Create a blood explosion / splatter effect
            GameObject splatterEffect = Instantiate(bloodSplatter, transform.position, Quaternion.identity) as GameObject;
            ParticleSystem parts = splatterEffect.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(splatterEffect, totalDuration);

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
