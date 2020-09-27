using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public GameObject goblin;
    
    void Start()
    {
        Instantiate(goblin, new Vector3(-1, 0, 0), Quaternion.identity);

        Invoke("SpawnGoblins", 2);
    }

    
    void Update()
    {
        
    }

    private void SpawnGoblins()
    {
        Instantiate(goblin, new Vector3(-1, 0, 0), Quaternion.identity);

        Invoke("SpawnGoblins", 2);
    }
}
