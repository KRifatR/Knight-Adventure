using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSlider : MonoBehaviour
{
    [SerializeField] private GameObject _health;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _enemy;
    private float _scaleX;

    [SerializeField] private float _addX;
    [SerializeField] private float _addY;
    private float _healthScaleX;

    private float _HP;
    private float _maxHP;

    private void Update()
    {
        _HP = _enemy.GetComponent<EnemyMovement>()._HP;
        _maxHP = _enemy.GetComponent<EnemyMovement>()._maxHP;
        _healthScaleX = _HP / _maxHP;
        _health.transform.localScale = new Vector3(_healthScaleX, _health.transform.localScale.y, _health.transform.localScale.z);
        _scaleX = transform.localScale.x;
        if (_scaleX < 0)
        {
            _health.transform.position = new Vector2(_enemy.transform.position.x + _addX, _enemy.transform.position.y + _addY);
            _background.transform.position = new Vector2(_enemy.transform.position.x + _addX, _enemy.transform.position.y + _addY);
        }
        else
        {
            _health.transform.position = new Vector2(_enemy.transform.position.x + _addX, _enemy.transform.position.y + _addY);
            _background.transform.position = new Vector2(_enemy.transform.position.x + _addX, _enemy.transform.position.y + _addY);
        }

    }
}
