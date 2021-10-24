using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceHealth : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    [SerializeField] private GameObject _liveX1;
    [SerializeField] private GameObject _liveX2;
    [SerializeField] private GameObject _liveX3;

    private Text _healthPoint;

    [SerializeField] private GameObject _player;
    private Vector2 _startPosition;
    private void Start()
    {
        _healthPoint = _text.GetComponent<Text>();
        _startPosition = _player.transform.position;
    }

    private void FixedUpdate()
    {
        _healthPoint.text = PlayerData.HealthPoint + " / " + PlayerData.MaxHealth;

        if (PlayerData.LiveCount == 3)
        {
            _liveX3.SetActive(true);
            _liveX2.SetActive(true);
            _liveX1.SetActive(true);
        }
        else if (PlayerData.LiveCount == 2)
        {
            _liveX3.SetActive(false);
            _liveX2.SetActive(true);
            _liveX1.SetActive(true);
        }
        else if (PlayerData.LiveCount == 1)
        {
            _liveX3.SetActive(false);
            _liveX2.SetActive(false);
            _liveX1.SetActive(true);
        }
        else if (PlayerData.LiveCount < 1)
        {
            _liveX3.SetActive(false);
            _liveX2.SetActive(false);
            _liveX1.SetActive(false);
        }



        if (PlayerData.HealthPoint <= 0 && PlayerData.LiveCount > 1)
        {
            PlayerData.LiveCount -= 1;
            PlayerData.HealthPoint = PlayerData.MaxHealth;
            _player.transform.position = _startPosition;
        }
        else if (PlayerData.HealthPoint <= 0 && PlayerData.LiveCount == 1)
        {
            PlayerData.LiveCount = 1;
            PlayerData.HealthPoint = PlayerData.MaxHealth;
            SceneManager.LoadScene(7);
        }

        if (PlayerData.HealthPoint >= PlayerData.MaxHealth)
        {
            PlayerData.HealthPoint = PlayerData.MaxHealth;
        }


    }
}
