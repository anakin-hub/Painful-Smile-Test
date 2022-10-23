using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] protected float _maxHP;
    [SerializeField] protected float _currentHP;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _maxSpeed;
    [SerializeField] protected float _rotationSpeed;
    [SerializeField] protected Vector3 _direction;
    [SerializeField] protected bool _dead;
    
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected HealthBar healthbar;

    [SerializeField] protected SpriteRenderer _shipRenderer;
    [SerializeField] protected Sprite _healthShip;
    [SerializeField] protected Sprite _littleDamagedShip;
    [SerializeField] protected Sprite _bigDamagedShip;
    [SerializeField] protected Sprite _destroyedShip;
    [SerializeField] protected GameObject _explosionPrefab;

    protected void Awake()
    {
        _shipRenderer.sprite = _healthShip;
        _currentHP = _maxHP;
        _dead = false;
    }

    protected void Start()
    {
        healthbar.SetHealthBar(_maxHP, _currentHP);
    }

    protected void FixedUpdate()
    {
        _direction = Quaternion.AngleAxis(rb.rotation, Vector3.forward) * Vector3.down;
    }

    protected void MoveFoward()
    {
        if(rb.velocity.magnitude <= _maxSpeed)
            rb.AddForce(_direction * _speed);
    }

    protected void RotateRight()
    {
        rb.rotation -= _rotationSpeed;
    }

    protected void RotateLeft()
    {
        rb.rotation += _rotationSpeed;
    }

    public void TakingDamage(float dmg)
    {
        _currentHP -= dmg;
        healthbar.SetHealthBar(_maxHP, _currentHP);
        CheckShipState();
    }

    protected void CheckShipState()
    {
        float HPnormalized = _currentHP / _maxHP;
        if( HPnormalized < 0.8 && HPnormalized >= 0.5 )
            _shipRenderer.sprite = _littleDamagedShip;
        if (HPnormalized < 0.5 && HPnormalized > 0)
            _shipRenderer.sprite = _bigDamagedShip;
        if (HPnormalized <= 0)
            _shipRenderer.sprite = _destroyedShip;
    }

    public void DeathScene()
    {
        _dead = true;
        GameObject explosion = Instantiate(_explosionPrefab, transform.position, transform.rotation);
        explosion.GetComponent<ShipExplosion>().SetShipPosition(transform);
    }
}
