using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("button clicked");
        SceneManager.LoadScene(1);
    }   

    public void Quit()
    {
        Application.Quit();
    }
   

}
