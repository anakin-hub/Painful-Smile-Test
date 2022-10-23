using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] protected float TimeOutSpeed;

    protected void Start()
    {
        Destroy(gameObject, TimeOutSpeed);
    }
}
