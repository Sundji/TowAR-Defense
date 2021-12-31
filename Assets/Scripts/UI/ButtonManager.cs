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
        SceneManager.LoadScene("Test Scene - Vuforia");
    }

    public void OnReturnClick()
    {
        SceneManager.LoadScene("Scene - Main Menu");
    }
}