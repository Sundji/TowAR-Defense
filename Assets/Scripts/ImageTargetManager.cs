using UnityEngine;

public class ImageTargetManager : MonoBehaviour
{
    [SerializeField] private GameObject _childObjectPrefab = null;

    private Transform _transform;

    private GameObject _childObject;

    private void Awake()
    {
        _transform = transform;
    }

    public void Appear()
    {
        if (GameManager.Instance.IsGameActive && _childObject != null)
        { 
            _childObject.SetActive(true); 
        }
        else if (!GameManager.Instance.IsGameActive)
        {
            if (_childObject != null) Destroy(_childObject);
            _childObject = Instantiate(_childObjectPrefab, _transform);
        }
    }

    public void Disappear()
    {  
        if (_childObject != null) _childObject.SetActive(false);
    }
}
