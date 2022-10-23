using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image _healthBarSprite;
    [SerializeField] protected float _reduceSpeed;
    [SerializeField] protected float _targetHP;

    public void SetHealthBar(float maxHP, float currentHP)
    {
        _targetHP = currentHP / maxHP;
    }

    private void Update()
    {
        _healthBarSprite.fillAmount = Mathf.MoveTowards(_healthBarSprite.fillAmount, _targetHP, _reduceSpeed * Time.deltaTime);
    }
}
