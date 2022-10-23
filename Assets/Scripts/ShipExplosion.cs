using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExplosion : Explosion
{
    [SerializeField] protected Transform _shipPosition;
    [SerializeField] protected bool _getPosition;

    private new void Start()
    {
        _getPosition = false;
        base.Start();
    }

    void Update()
    {
        if (_getPosition)
            transform.position = _shipPosition.position;
    }

    public void SetShipPosition(Transform ship)
    {
        _shipPosition = ship;
        _getPosition = true;
    }
}
