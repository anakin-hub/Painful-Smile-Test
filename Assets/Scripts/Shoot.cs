using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] protected float _speed = 10;
    [SerializeField] protected float _damage;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected GameObject _explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ship ship))
        {
            collision.gameObject.GetComponent<Ship>().TakingDamage(_damage);
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
