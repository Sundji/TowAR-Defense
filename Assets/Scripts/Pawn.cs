using UnityEngine;

public class Pawn : MonoBehaviour
{
    private float MAX_HEALTH = 100f;
    private float FIRE_RATE = 3f;
    public enum PawnType { FRIENDLY, TOWER, ENEMY_MELEE, ENEMY_RANGE }
    public PawnType _type;
    public Transform _transform;
    public Bullet _bullet;
    public float _health;

    bool once = true;
    private float _nextFire = 0f;


    private void Start()
    {
        _transform = this.transform;
        _health = MAX_HEALTH;
    }

    private void Update()
    {
        if (this._type == PawnType.FRIENDLY && (Time.time > _nextFire))
        {
            _nextFire = Time.time + FIRE_RATE;

            Pawn nextTarget = GameManager.Instance.FindClosestTarget(_transform.position, _type);

            Bullet firedBullet = Instantiate(_bullet, _transform.Find("SpawnProjectile").transform);

            Vector3 fireDirection = (nextTarget.transform.position - _transform.position).normalized;

            firedBullet.GetComponent<Bullet>().Fire(fireDirection);
        }
    }

    public void loseHealth(float recievedDamage)
    {
        _health -= recievedDamage;
        if (_health <= 0f)
        {
            GameManager.Instance.pawnDead(this);
            Destroy(gameObject);
        }
    }
}
