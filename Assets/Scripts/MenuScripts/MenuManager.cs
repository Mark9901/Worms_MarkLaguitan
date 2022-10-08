using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject mainUI;

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Options()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        controlsUI.SetActive(true);
        mainUI.SetActive(false);

    }

    public void BackButton()
    {
        controlsUI.SetActive(false);
        mainUI.SetActive(true);
    }


}
