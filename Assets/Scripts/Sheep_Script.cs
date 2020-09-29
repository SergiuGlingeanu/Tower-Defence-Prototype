using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_Script : MonoBehaviour
{
    private Vector2 _destination;
    private Vector2 _direction, _position;

    private Transform _player;
    private CircleCollider2D _cc;

    private bool _scared, _gotDestination;

    public float sheepSpeed;
    public float scareDistance;

    public float range, attackCooldown, damage;
    public int health;
    public Sprite[] healthSprite;

    public GameObject bullet;

    private float x;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();

        GetDestination();

        _cc = GetComponent<CircleCollider2D>();
        _cc.radius = range;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, _destination) < 0.5f)
        {
            _gotDestination = false;
            GetDestination();
        }

        if (Vector2.Distance(transform.position, _player.position) < (float)scareDistance)
        {
            _scared = true;
            _gotDestination = false;
            _direction = transform.position - _player.position;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position +_direction, sheepSpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, _player.position) >= (float)scareDistance)
        {
            _scared = false;
            GetDestination();
            transform.position = Vector2.MoveTowards(transform.position, _destination, sheepSpeed * Time.deltaTime);
        }

        if (health > 4)
        {
            Destroy(this.gameObject);
        }

        this.GetComponent<SpriteRenderer>().sprite = healthSprite[health];

    }

    private void GetDestination()
    {
        if (!_scared && !_gotDestination)
        {
            _destination = new Vector2(Random.Range(-19f, 14f), Random.Range(-14f, 10f));

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health++;
        }
    }
}
