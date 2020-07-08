using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReseterSCript : MonoBehaviour
{
    public Button resetButton, homeButton, quitbutton;

    //void Start()
    //{
    //    resetButton.onClick.AddListener(reseter);
    //    homeButton.onClick.AddListener(homer);
    //}

    public void reseter()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void homer()
    {
        SceneManager.LoadScene(0);
    }

    public void quiter()
    {
        Application.Quit();
    }
}
