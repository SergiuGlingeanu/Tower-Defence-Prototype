using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_Script : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _destination;
    private Vector2 _direction, _position;

    private Transform _player;

    private bool _scared, _gotDestination;

    public float sheepSpeed;
    public float scareDistance;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();

        _rb = GetComponent<Rigidbody2D>();
        GetDestination();
    }

    // Update is called once per frame
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

            Debug.Log("Far Away");
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

            Debug.Log("Going");
        }
    }
}
