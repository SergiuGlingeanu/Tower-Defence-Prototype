using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playr_Scripts : MonoBehaviour
{

    private Rigidbody2D _rb;

    public float playerSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);
    }
}
