using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemies
{
    [SerializeField] protected bool _attacking;
    [SerializeField] protected Cannon _cannon;
    
    new void Start()
    {
        base.Start();
        _attacking = false;
    }

    new void Update()
    {
        base.Update();
        if (_attacking && !_dead)
        {            
            _cannon.Shooting();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _attacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _attacking = false;
        }
    }
}
