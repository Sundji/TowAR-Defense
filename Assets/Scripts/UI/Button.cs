using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void onExitClick()
    {
        Application.Quit();
    }

    public void onTutorialClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void onPlayClick()
    {
        SceneManager.LoadScene("Test Scene - Vuforia");
    }

    public void onReturnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}