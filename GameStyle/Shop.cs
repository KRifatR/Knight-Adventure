using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _weaponUpText;
    [SerializeField] private GameObject _healthPointUpText;
    [SerializeField] private GameObject _mextureAddText;
    [SerializeField] private GameObject _liveAddText;

    [SerializeField] private float _weaponUpScore;
    [SerializeField] private float _healthPointUpScore;
    [SerializeField] private float _mextureAddScore;
    [SerializeField] private float _liveAddScore;

    [SerializeField] private float _dmgUp;
    [SerializeField] private float _maxHpUp;

    private void Update()
    {
        
        PlayerData.DmgUp = _dmgUp;
        _weaponUpText.GetComponent<Text>().text = _weaponUpScore + "";
        _healthPointUpText.GetComponent<Text>().text = _healthPointUpScore + "";
        _mextureAddText.GetComponent<Text>().text = _mextureAddScore + "";
        _liveAddText.GetComponent<Text>().text = _liveAddScore + "";
    }
    public void WeaponUp()
    {
        if (PlayerData.CoinCount >= _weaponUpScore)
        {
            PlayerData.CoinCount -= _weaponUpScore;
            PlayerData.WeaponUpLvl += 1f;
        }
    }

    public void HealthPointUp()
    {
        if (PlayerData.CoinCount >= _healthPointUpScore)
        {
            PlayerData.MaxHealth = PlayerData.MaxHealth + _maxHpUp;
            PlayerData.CoinCount = PlayerData.CoinCount - _healthPointUpScore;
        }
    }

    public void MextureAdd()
    {
        if (PlayerData.CoinCount >= _mextureAddScore)
        {
            PlayerData.MixturesCount = PlayerData.MixturesCount + 1;
            PlayerData.CoinCount = PlayerData.CoinCount - _mextureAddScore;
        }
        else
        {
            PlayerData.MixturesCount = PlayerData.MixturesCount +0;
            PlayerData.CoinCount = PlayerData.CoinCount +0;
        }
    }

    public void LiveAdd()
    {
        if (PlayerData.CoinCount >= _liveAddScore)
        {
            PlayerData.LiveCount = PlayerData.LiveCount + 1;
            PlayerData.CoinCount = PlayerData.CoinCount - _liveAddScore;
        }
    }
}
