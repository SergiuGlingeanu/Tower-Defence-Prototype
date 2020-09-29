using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public GameObject goblin, gem;

    public float goblinsPerSecond, gemCooldown;
    
    void Start()
    {
        Instantiate(goblin, new Vector3(-15.5f, 10.5f, 0), Quaternion.identity);

        Invoke("SpawnGoblins", 1 / goblinsPerSecond);

        Invoke("SpawnGem", gemCooldown);
    }

    
    void Update()
    {
        
    }

    private void SpawnGoblins()
    {
        Instantiate(goblin, new Vector3(-15.5f, 10.5f, 0), Quaternion.identity);

        Invoke("SpawnGoblins", 1 / goblinsPerSecond);
    }

    private void SpawnGem()
    {
        Instantiate(gem, new Vector3(Random.Range(-19.5f, 14.5f), Random.Range(-10.5f, 10.5f), 0), Quaternion.identity);

        Invoke("SpawnGem", gemCooldown);
    }
}
