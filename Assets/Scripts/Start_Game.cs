using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
   

    public void startGame()
    {
        SceneManager.LoadScene("Sergiu's Scene");
    }
}
