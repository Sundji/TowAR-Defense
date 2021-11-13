using UnityEngine;

public class Pawn : MonoBehaviour
{
    private float MAX_HEALTH = 100f;
    public enum PawnType { FRIENDLY, TOWER, ENEMY_MELEE, ENEMY_RANGE }
    public PawnType _type;
    public Transform _transform;
    public Bullet _bullet;
    public float _health;

    bool once = true;
    

    private void Start()
    {
        _transform = this.transform;
        _health = MAX_HEALTH;
    }

    private void Update()
    {
        if (this._type == PawnType.FRIENDLY && once)
        {
            //Debug.Log(GameManager.Instance.FindClosestTarget(_transform.position, _type)._type);
            Pawn nextTarget = GameManager.Instance.FindClosestTarget(_transform.position, _type);

            Bullet firedBullet = Instantiate(_bullet, _transform.Find("SpawnProjectile").transform);

            Vector3 fireDirection = (nextTarget.transform.position - _transform.position).normalized;

            firedBullet.GetComponent<Bullet>().Prepare(fireDirection);
            once = false;

        }
    }

    public void loseHealth(float recievedDamage)
    {
        _health -= recievedDamage;
    }
}
