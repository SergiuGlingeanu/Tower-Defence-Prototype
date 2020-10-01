using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    public Button start;

    public GameObject startButton;

    void Start()
    {
        
        start.OnClick.AddListener(startGame);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Sergiu's Scene");
    }
}
