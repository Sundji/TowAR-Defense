using UnityEngine;
using UnityEngine.UI;

public class GameViewManager : MonoBehaviour
{
    [Header("End Game View")]
    [SerializeField] private GameObject _endGameView = null;
    [SerializeField] private Text _endGameText = null;

    [Header("In Game View")]
    [SerializeField] private GameObject _inGameView = null;

    [Header("Set Up View")]
    [SerializeField] private GameObject _setUpView = null;
    [SerializeField] private Button _setUpFinishButton = null;
    [SerializeField] private Text _setUpText = null;

    private void Awake()
    {
        Time.timeScale = 1;

        _setUpView.SetActive(true);
        _inGameView.SetActive(false);
        _endGameView.SetActive(false);

        _setUpFinishButton.onClick.AddListener(FinishSetUp);

        EventManager.Instance.OnGameEndEvent.AddListener(OnGameEnd);
    }

    private void OnGameEnd(bool isVictory)
    {
        _setUpView.SetActive(false);
        _inGameView.SetActive(false);
        _endGameView.SetActive(true);
        _endGameText.text = string.Format("You have {0}!", isVictory ? "won" : "lost");
    }

    private void FinishSetUp()
    {
        string message = string.Empty;
        bool canFinish = GameManager.Instance.CheckIfCanStartGame(out message);

        if (!canFinish)
        {
            _setUpText.text = message;
            return;
        }

        _setUpView.SetActive(false);
        _inGameView.SetActive(true);
        _endGameView.SetActive(false);

        EventManager.Instance.OnGameStartEvent.Invoke();
    }
}
