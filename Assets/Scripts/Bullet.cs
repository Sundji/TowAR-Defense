using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    bool _isFired;
    float _flySpeed = 5f;
    float _damage = 25f;


    public void Fire(Vector3 direction)
    {
        _direction = direction;
        _isFired = true;

    }


    // Update is called once per frame
    void Update()
    {
        if (_isFired)
        {
            transform.position += _direction * _flySpeed * Time.deltaTime;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pawn>() != null)
        {
            other.GetComponent<Pawn>().loseHealth(_damage);
            Destroy(gameObject);
        }
    }

}
