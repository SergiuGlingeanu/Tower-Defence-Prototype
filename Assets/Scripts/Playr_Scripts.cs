using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playr_Scripts : MonoBehaviour
{

    private Rigidbody2D _rb;

    public float playerSpeed, gems;

    public Text gemText;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);

        gemText.text = gems.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gems")
        {
            Destroy(collision.gameObject);
            gems += 10;
        }
    }
}
