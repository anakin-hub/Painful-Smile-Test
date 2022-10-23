using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelCannon : Cannon
{
    [SerializeField] protected Transform CannonPoint_Up;
    [SerializeField] protected Transform CannonPoint_Down;


    public void ParallelShoot()
    {
        if(_recharged)
        {
            Shooting(CannonPoint);
            Shooting(CannonPoint_Up);
            Shooting(CannonPoint_Down);
            StartCoroutine(RechargingCannon());
        }
    }

    void Shooting(Transform ShootPoint)
    {
        GameObject ball = Instantiate(BallPrefab, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.right * _cannonForce, ForceMode2D.Impulse);
    }
}
