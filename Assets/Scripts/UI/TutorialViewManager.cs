using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialViewManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pageViews = new List<GameObject>();
    [SerializeField] private Button _buttonLeft = null;
    [SerializeField] private Button _buttonRight = null;

    private int _currentIndex = 0;

    private void Awake()
    {
        _buttonLeft.onClick.AddListener(OnLeftClick);
        _buttonRight.onClick.AddListener(OnRightClick);
        UpdateButtonInteractability();
    }

    private void OnLeftClick()
    {
        if (_currentIndex > 0)
        {
            _pageViews[_currentIndex].SetActive(false);
            _currentIndex--;
            _pageViews[_currentIndex].SetActive(true);
            UpdateButtonInteractability();
        }
    }

    private void OnRightClick()
    {
        if (_currentIndex < _pageViews.Count - 1)
        {
            _pageViews[_currentIndex].SetActive(false);
            _currentIndex++;
            _pageViews[_currentIndex].SetActive(true);
            UpdateButtonInteractability();
        }
    }

    private void UpdateButtonInteractability()
    {
        _buttonLeft.interactable = _currentIndex == 0 ? false : true;
        _buttonRight.interactable = _currentIndex == _pageViews.Count - 1 ? false : true;
    }
}
