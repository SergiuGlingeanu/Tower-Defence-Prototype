using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_Script : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _destination;
    private Vector2 _direction, _position;

    private Transform _player;
    private CircleCollider2D _cc;

    private bool _scared, _gotDestination;

    public float sheepSpeed;
    public float scareDistance;

    public float range, attackCooldown, damage, health;

    public GameObject bullet;

    private float x;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();

        _rb = GetComponent<Rigidbody2D>();
        GetDestination();

        _cc = GetComponent<CircleCollider2D>();
        _cc.radius = range;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, _destination) < 0.5)
        {
            _gotDestination = false;
            GetDestination();
        }

        if (Vector2.Distance(transform.position, _player.position) < scareDistance)
        {
            _scared = true;
            _gotDestination = false;
            _direction = transform.position - _player.position;
            _rb.velocity = _direction.normalized * sheepSpeed;
        }
        if (Vector2.Distance(transform.position, _player.position) >= scareDistance)
        {
            _scared = false;
            GetDestination();
        }
    }

    private void GetDestination()
    {
        if (!_scared && !_gotDestination)
        {
            _destination = new Vector2(Random.Range(-9, 9), Random.Range(-5, 5));

            _position = new Vector2(transform.position.x, transform.position.y);

            _direction = _destination - _position;

            _rb.velocity = _direction.normalized * sheepSpeed;

            _gotDestination = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            x += 1 * Time.deltaTime;

            if (x > attackCooldown)
            {
                GameObject _bullet;

                _bullet = Instantiate(bullet, transform.position, Quaternion.identity);

                Vector2 _enemy = collision.transform.position;
                Vector2 _bulletDirection = _enemy - (Vector2)transform.position;

                _bullet.GetComponent<Rigidbody2D>().velocity = _bulletDirection.normalized * 10;
                _bullet.GetComponent<Bullet_Script>().damage = damage;

                x = 0;
            }
        }
    }
}
