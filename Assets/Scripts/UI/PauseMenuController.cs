using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    /// <summary>
    /// Class for handling game flow
    /// </summary>
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu = null;

        /// <summary>
        /// Function that pauses the game on button click and reveals pause menu.
        /// </summary>
        public void PauseGame()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        /// <summary>
        /// Function that continues the game on button click.
        /// </summary>
        public void ResumeGame()
        {
            _pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        /// <summary>
        /// Function that reloads the current scene on button click, restarting the game.
        /// </summary>
        public void RestartGame()
        {
            _pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// Function that ends the game on button click, exiting to main menu.
        /// </summary>
        public void QuitToMainMenu()
        {
            SceneManager.LoadScene("Scene - Main Menu");
        }
    }
}

