using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private GameObject _health;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _player;
    private float _scaleX;

    [SerializeField] private float _addX;
    [SerializeField] private float _addY;
    private float _healthScaleX;
   
    private void Update()
    {
        _healthScaleX = PlayerData.HealthPoint / PlayerData.MaxHealth;
        _health.transform.localScale = new Vector3(_healthScaleX, _health.transform.localScale.y, _health.transform.localScale.z);
        _scaleX = transform.localScale.x;
        if (_scaleX < 0)
        {
            _health.transform.position = new Vector2(_player.transform.position.x + _addX , _player.transform.position.y + _addY);
            _background.transform.position = new Vector2(_player.transform.position.x + _addX, _player.transform.position.y + _addY);
        }
        else
        {
            _health.transform.position = new Vector2(_player.transform.position.x + _addX, _player.transform.position.y + _addY);
            _background.transform.position = new Vector2(_player.transform.position.x + _addX, _player.transform.position.y + _addY);
        }
    }
}
