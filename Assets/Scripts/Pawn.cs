using System.Collections;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private PawnType _type = PawnType.PAWN_FRIENDLY;

    [Header("Health Information")]
    [SerializeField] private float _healthMaximum = 0.0f;

    [Header("Shooting Information")]
    [SerializeField] private Bullet _bulletPrefab = null;
    [SerializeField] private Transform _bulletSpawnPoint = null;
    [SerializeField] private float _shootingWaitTime = 0.0f;

    private Transform _transform;

    private bool _isActive = false;
    private bool _isInitialized = false;

    private float _health;
    private float _timer;

    private Pawn _target;

    public PawnType Type { get { return _type; } }

    private void Awake()
    {
        EventManager.Instance.OnGameEndEvent.AddListener(OnGameEnd);
        EventManager.Instance.OnGameStartEvent.AddListener(OnGameStart);
        EventManager.Instance.OnPawnDeathEvent.AddListener(OnPawnDeath);
    }

    private void Start()
    {
        _health = _healthMaximum;
        _timer = 0.0f;
        _transform = transform;

        EventManager.Instance.OnPawnCreatedEvent.Invoke(this);
    }

    private void Update()
    {
        if (!_isActive) return;

        _timer += Time.deltaTime;

        if (!_isInitialized)
        {
            _isInitialized = true;
            _target = GameManager.Instance.FindClosestTarget(_transform.position, _type);
        }
        if (_target != null && _timer > _shootingWaitTime)
        {
            _timer = 0.0f;
            Vector3 direction = (_target.transform.position - _transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
            bullet.Fire(direction);
        }
    }

    private IEnumerator WaitAndFindNewTarget()
    {
        yield return new WaitForEndOfFrame();
        _target = GameManager.Instance.FindClosestTarget(_transform.position, _type);
    }

    private void OnGameEnd(bool isVictory)
    {
        _isActive = false;
    }

    private void OnGameStart()
    {
        _isActive = true;
    }

    private void OnPawnDeath(Pawn pawn)
    {
        if (_target != null && _target == pawn) StartCoroutine("WaitAndFindNewTarget");
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0.0f)
        {
            EventManager.Instance.OnPawnDeathEvent.Invoke(this);
            Destroy(gameObject);
        }
    }
}
