using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playr_Scripts : MonoBehaviour
{

    private Rigidbody2D _rb;

    public float playerSpeed;
    private AudioSource dogAudio;
    private bool dogMoving;
    public bool m_Play;
    public bool m_ToggleChange;
    public bool dogIsMoving;

    public int gems;
    public Text gemsText;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        dogAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);

        playDogSounds();

        gemsText.text = gems.ToString();
    }

    public void playDogSounds()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) //Dog started running
        {
            dogIsMoving = true;
            m_Play = true;
            m_ToggleChange = true;
        }

        if (!(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))) //Dog isn't moving
        {
            dogIsMoving = false;
            m_Play = false;
            m_ToggleChange = true;
        }

        //Check to see if you just set the toggle to positive
        if (m_Play == true && m_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            dogAudio.Play();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio
            dogAudio.Stop();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gems")
        {
            gems += 10;

            Destroy(collision.gameObject);
        }
    }
}
