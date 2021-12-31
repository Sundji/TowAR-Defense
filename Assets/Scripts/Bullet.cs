using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private List<PawnType> _pawnTypesToHit = new List<PawnType>();
    [SerializeField] private float _damageAmount = 0.0f;
    [SerializeField] private float _speed = 0.0f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pawn>() == null) return;

        Pawn pawn = other.GetComponent<Pawn>();
        if (_pawnTypesToHit.Contains(pawn.Type))
        {
            pawn.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }

    public void Fire(Vector3 direction)
    {
        Debug.Log(direction);
        _rigidbody.AddForce(direction * _speed, ForceMode.Impulse);
    }
}
