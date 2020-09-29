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
    public float showDamageTimer;
    public Sprite fullHealthGoblin, damagedGoblin;

    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = new Vector3(1, 0, 0);

        showDamageTimer = 0;

    }

    
    void Update()
    {
        ShowGoblinTakingDamage();

        if (health <= 0)
        {
            //Create a blood explosion / splatter effect
            GameObject splatterEffect = Instantiate(bloodSplatter, transform.position, Quaternion.identity) as GameObject;
            ParticleSystem parts = splatterEffect.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(splatterEffect, totalDuration);

            //Make sound controller play goblin death sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().goblinSplatted = true;

            Destroy(this.gameObject);
        }
    }

    void ShowGoblinTakingDamage()
    {
        var goblinRenderer = GetComponent<SpriteRenderer>();

        if (health > 50)
        {
            goblinRenderer.sprite = fullHealthGoblin;
        }
        else
        {
            goblinRenderer.sprite = damagedGoblin;
        }

        if (showDamageTimer > 0)
        {
            //Make the goblin red
            goblinRenderer.material.SetColor("_Color", Color.red);

            showDamageTimer -= 0.1f;
        }

        else
        {
            showDamageTimer = 0;
            //Revert goblin colour back to normal
            goblinRenderer.material.SetColor("_Color", Color.white);
        }
    }
}
