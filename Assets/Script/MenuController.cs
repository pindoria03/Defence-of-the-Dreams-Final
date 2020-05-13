using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void loadmainworld()
    {
        SceneManager.LoadScene(1); //load main level
    }

    public void exitgame()
    {
        Application.Quit(); //exit application
    }
}
