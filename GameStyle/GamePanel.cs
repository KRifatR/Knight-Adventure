using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePanel : MonoBehaviour
{
   
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _mixtures;
    [SerializeField] private GameObject _playerParameters;
    [SerializeField] private GameObject _map;
    [SerializeField] private GameObject _options;

    private void Start()
    {
        _shop.SetActive(false);
        _mixtures.SetActive(true);
        _playerParameters.SetActive(false);
        _options.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_shop.activeInHierarchy == false)
            {
                _shop.SetActive(true);
            }
            else if (_shop.activeInHierarchy == true)
            {
                _shop.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_playerParameters.activeInHierarchy == false)
            {
                _playerParameters.SetActive(true);
            }
            else if (_playerParameters.activeInHierarchy == true)
            {
                _playerParameters.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (PlayerData.MapActiv == 0)
            {
                _map.SetActive(true);
                PlayerData.MapActiv = 1;
            }
            else if (PlayerData.MapActiv == 1)
            {
                _map.SetActive(false);
                PlayerData.MapActiv = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_options.activeInHierarchy == false)
            {
                if (_shop.activeInHierarchy == true || _playerParameters.activeInHierarchy == true)
                {
                    _shop.SetActive(false);
                    _playerParameters.SetActive(false);
                }
                else if (_shop.activeInHierarchy == false && _playerParameters.activeInHierarchy == false)
                {
                    _options.SetActive(true);
                }
            }
            else if (_options.activeInHierarchy == true)
            {
                _options.SetActive(false);
            }
        }
    }
    public void OpenShop()
    {
        if (_shop.activeSelf == false)
        {
            _shop.SetActive(true);
        }
        else if(_shop.activeSelf == true)
        {
            _shop.SetActive(false);
        }
    }
    public void OpenMap()
    {
        if (_map.activeInHierarchy == false)
        {
            _map.SetActive(true);
        }
        else if (_map.activeInHierarchy == true)
        {
            _map.SetActive(false);
        }
    }
    public void OpenPlayerParameters()
    {
        if (_playerParameters.activeInHierarchy == false)
        {
            _playerParameters.SetActive(true);
        }
        else if (_playerParameters.activeInHierarchy == true)
        {
            _playerParameters.SetActive(false);
        }
    }
}
