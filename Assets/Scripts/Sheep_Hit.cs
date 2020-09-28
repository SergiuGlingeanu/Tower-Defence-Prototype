using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_Hit : MonoBehaviour
{
    public Sprite[] sheepStyle;

    public int sheepHealth;
    
    
    void Start()
    {
        sheepHealth = 0;
    }

    
    void Update()
    {
        
        if (sheepHealth > 4)
        {
            Destroy(this.gameObject);
        }
        
        /*
        if (Input.GetKeyDown("o"))
        {
            sheepHealth++;
        }
        */

        Debug.Log(sheepHealth);
        
        this.GetComponent<SpriteRenderer>().sprite = sheepStyle[sheepHealth];
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            sheepHealth++;
        }
    }
}
