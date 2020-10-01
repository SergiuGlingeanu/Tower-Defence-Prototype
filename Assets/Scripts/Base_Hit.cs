using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_Hit : MonoBehaviour
{
    public Sprite[] baseSprite;

    [Range(0, 50)] public int baseHealthStart;

    private int baseHealth;

    [Range(0, 10)] public int damageAm;

    public bool baseDead;

    public bool baseHalf;

    public Text healthCount;

    public GameObject dieUI;

    public GameObject healthUI;

    void Start()
    {
        baseHealth = baseHealthStart;
    }

    void Update()
    {
        healthCount.text = baseHealth.ToString();

        if (baseHealth <= baseHealthStart / 2)
        {
            baseHalf = true;
        }
        
        if (baseHealth <= 0)
        {
            baseDead = true;
        }

        if (baseHalf == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = baseSprite[0];
        }
        
        if (baseDead == true)
        {
            dieUI.SetActive(true);
            
            healthUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Make sound controller play base damage sounds
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sound_Controller_Script>().baseDamaged = true;

            baseHealth -= damageAm;

            Destroy(collision.gameObject);
        }
    }
}
