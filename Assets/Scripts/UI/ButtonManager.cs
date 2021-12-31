using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnTutorialClick()
    {
        SceneManager.LoadScene("Scene - Tutorial");
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Scene - Game");
    }

    public void OnReturnClick()
    {
        SceneManager.LoadScene("Scene - Main Menu");
    }
}