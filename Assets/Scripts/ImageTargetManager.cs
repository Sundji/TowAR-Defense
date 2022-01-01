using UnityEngine;

public class ImageTargetManager : MonoBehaviour
{
    private enum ImageTargetType { LEVEL, PAWN, NONE };

    [SerializeField] private GameObject _childObjectPrefab = null;
    [SerializeField] private ImageTargetType _imageTargetType = ImageTargetType.NONE;   
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
            bool shouldAppear = true;
            if (_imageTargetType == ImageTargetType.LEVEL) shouldAppear = GameManager.Instance.ActivateLevelImageTarget();
            else if (_imageTargetType == ImageTargetType.PAWN) shouldAppear = GameManager.Instance.ActivatePawnImageTarget();
            if (shouldAppear) _childObject.SetActive(true); 
        }
        else if (!GameManager.Instance.IsGameActive)
        {
            if (_childObject != null) Destroy(_childObject);
            bool shouldAppear = true;
            if (_imageTargetType == ImageTargetType.LEVEL) shouldAppear = GameManager.Instance.ActivateLevelImageTarget();
            else if (_imageTargetType == ImageTargetType.PAWN) shouldAppear = GameManager.Instance.ActivatePawnImageTarget();
            if (shouldAppear) _childObject = Instantiate(_childObjectPrefab, _transform);
        }
    }

    public void Disappear()
    {
        if (_childObject != null)
        {
            _childObject.SetActive(false);
            if (_imageTargetType == ImageTargetType.LEVEL) GameManager.Instance.DeactivateLevelImageTarget();
            else if (_imageTargetType == ImageTargetType.PAWN) GameManager.Instance.DeactivatePawnImageTarget();
        }
    }
}
