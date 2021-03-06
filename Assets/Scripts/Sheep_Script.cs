﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheep_Script : MonoBehaviour
{
    private Vector2 _destination;
    private Vector2 _direction, _position;

    private Transform _upgradeTile, _playerTransform;
    private GameObject _player;
    private Playr_Scripts _playerScript;
    private CircleCollider2D _cc;

    public GameObject buttons, healButton;

    private bool _scared, _gotDestination, upgrading;

    public float sheepSpeed;
    public float scareDistance;

    private int _damagePrice = 50, _attackPrice = 50, healPrice;
    public Text damageText, attackText, healText;

    public float range, attackCooldown, damage;
    public int health;
    public Sprite[] healthSprite;

    public GameObject bullet;

    public GameObject bloodSplatter;
    public float showDamageTimer;



    private float x;

    void Start()
    {
        _player = GameObject.Find("Player");
        _playerTransform = _player.GetComponent<Transform>();
        _playerScript = _player.GetComponent<Playr_Scripts>();
        _upgradeTile = GameObject.Find("UpgradeTile").GetComponent<Transform>();

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

        if (Vector2.Distance(transform.position, _playerTransform.position) < (float)scareDistance)
        {
             if (transform.position.x > -19f && transform.position.x < 14f &&
               transform.position.y > -10f && transform.position.y < 10f)
           {
            _scared = true;
            _gotDestination = false;
            _direction = transform.position - _playerTransform.position;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + _direction, sheepSpeed * Time.deltaTime);
            }
            else { 
            _scared = false;
            GetDestination();
            transform.position = Vector2.MoveTowards(transform.position, _destination, sheepSpeed * Time.deltaTime);
            }

        }
        if (Vector2.Distance(transform.position, _playerTransform.position) >= (float)scareDistance)
        {
            _scared = false;
            GetDestination();
            transform.position = Vector2.MoveTowards(transform.position, _destination, sheepSpeed * Time.deltaTime);
        }

        if (health > 4)
        {
            //Make sound controller play dying sheep sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().sheepKilled = true;

            //Create a blood explosion / splatter effect
            GameObject splatterEffect = Instantiate(bloodSplatter, transform.position, Quaternion.identity) as GameObject;
            ParticleSystem parts = splatterEffect.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(splatterEffect, totalDuration);


            Destroy(this.gameObject);
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = healthSprite[health];
        }

        if (upgrading)
        {
            transform.position = _upgradeTile.position + new Vector3(0, 0, -2);
        }

        if (Vector2.Distance(transform.position, _upgradeTile.position) < 1f && _scared)
        {
            upgrading = true;

            buttons.SetActive(true);

            if (health > 0)
            {
                healButton.SetActive(true);

                healPrice = health * 20;

                healText.text = healPrice.ToString();

            } else
            {
                healButton.SetActive(false);
            }
        }

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

                //Make sound controller play goblin death sounds
                GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().shotFired = true;

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
            //Make sound controller play sheep hurt sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().sheepHurt = true;
        }
    }

    public void MoreDamage()
    {
        if (_playerScript.gems >= _damagePrice)
        {
            //Make sound controller play upgrade sheep sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().sheepUpgraded = true;

            damage += 20;

            _playerScript.gems -= _damagePrice;

            _damagePrice += 50;

            damageText.text = _damagePrice.ToString();
        }
    }

    public void AttackSpeed()
    {
        if (_playerScript.gems >= _attackPrice)
        {
            //Make sound controller play upgrade sheep sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().sheepUpgraded = true;

            attackCooldown -= 0.2f;

            _playerScript.gems -= _attackPrice;

            _attackPrice += 50;

            attackText.text = _attackPrice.ToString();

        }
    }

    public void HealSheep()
    {
        if (_playerScript.gems >= healPrice)
        {
            //Make sound controller play upgrade sheep sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().sheepUpgraded = true;

            health = 0;

            _playerScript.gems -= healPrice;
        }
    }

    public void StopUpgrading()
    {
        upgrading = false;
    }
}
