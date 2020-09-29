﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Script : MonoBehaviour
{

    public float health = 100;
    public float speed = 2;
    public float damage = 2;
    public float attackCooldown = 2;
    public GameObject bloodSplatter;

    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = new Vector3(1, 0, 0);
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
    }
}
