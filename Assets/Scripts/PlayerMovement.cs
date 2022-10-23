using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Ship
{
    [SerializeField] protected ParallelCannon CannonLeft;
    [SerializeField] protected ParallelCannon CannonRight;
    [SerializeField] protected Cannon CannonFront;



    private void Update()
    {
        if (!_dead)
        {
            if (Input.GetKey(KeyCode.W))
                MoveFoward();

            if (Input.GetKey(KeyCode.D))
                RotateRight();
            else if (Input.GetKey(KeyCode.A))
                RotateLeft();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CannonLeft.ParallelShoot();
                CannonRight.ParallelShoot();
                CannonFront.Shooting();
            }
        }
        else
            rb.velocity = Vector3.zero;
    }

    public float GetCurrentHP()
    { return _currentHP; }
}
