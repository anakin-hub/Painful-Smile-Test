using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : Enemies
{
    [SerializeField] protected float _collisionDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ship ship))
        {
            collision.gameObject.GetComponent<Ship>().TakingDamage(_collisionDamage);
            DeathScene();
        }        
    }
}
