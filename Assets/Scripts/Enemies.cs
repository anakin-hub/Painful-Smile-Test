using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Ship
{
    [SerializeField] protected Transform _target;
    [SerializeField] protected Vector3 _targetDirection;
    [SerializeField] protected GameManager _gameManager;


    protected new void Awake()
    {
        base.Awake();
        _gameManager = FindObjectOfType<GameManager>();
        _target = FindObjectOfType<PlayerMovement>().transform;
    }

    protected void Update()
    {
        if (!_dead)
        {
            _targetDirection = _target.position - transform.position;

            transform.up = Vector3.MoveTowards(transform.up, -_targetDirection, _rotationSpeed * Time.deltaTime);

            MoveFoward();
            if (_currentHP <= 0)
            {
                _gameManager.Reward();
                DeathScene();
            }
        }
        else
            rb.velocity = Vector2.zero;
    }

    protected new void DeathScene()
    {
        base.DeathScene();
        Destroy(gameObject, 1.5f);
    }
}
