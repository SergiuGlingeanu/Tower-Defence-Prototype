using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Goblin_Script>().health -= damage;
            collision.gameObject.GetComponent<Goblin_Script>().showDamageTimer = 1f;
        }

        Destroy(this.gameObject);
    }

}
