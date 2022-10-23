using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] protected bool _recharged;
    [SerializeField] protected float _rechargeTime;
    [SerializeField] protected float _cannonForce;

    [SerializeField] protected Transform CannonPoint;
    [SerializeField] protected GameObject BallPrefab;

    private void Start()
    {
        _recharged = true;
    }

    public void Shooting()
    {
        if (_recharged)
        {
            GameObject ball = Instantiate(BallPrefab, CannonPoint.position, CannonPoint.rotation);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.AddForce(CannonPoint.right * _cannonForce, ForceMode2D.Impulse);
            StartCoroutine(RechargingCannon());
        }
    }

    public bool GetRecharged()
    {
        return _recharged;
    }

    protected IEnumerator RechargingCannon()
    {
        _recharged = false;

        yield return new WaitForSeconds(_rechargeTime);

        _recharged = true;
    }
}
