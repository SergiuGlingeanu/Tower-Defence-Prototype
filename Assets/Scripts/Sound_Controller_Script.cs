using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller_Script : MonoBehaviour
{
    public AudioSource goblinSplatSource;
    public bool goblinSplatted;

    public AudioSource shotFiredSource, sheepUpgradeSource, sheepHurtSource, sheepKilledSource;
    public bool shotFired, sheepUpgraded, sheepHurt, sheepKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goblinSplatted)
        {
            goblinSplatSource.Play();
            goblinSplatted = false;
        }

        if (shotFired)
        {
            shotFiredSource.Play();
            shotFired = false;
        }

        if (sheepUpgraded)
        {
            sheepUpgradeSource.Play();
            sheepUpgraded = false;
        }

        if (sheepHurt)
        {
            sheepHurtSource.Play();
            sheepHurt = false;
        }

        if (sheepKilled)
        {
            sheepKilledSource.Play();
            sheepKilled = false;
        }
    }
}
