using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_script : MonoBehaviour
{
    public Text healthText;
    public int baseHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            baseHealth--;
            healthText.text = baseHealth.ToString();

            Destroy(collision.gameObject);
        }
    }
}
