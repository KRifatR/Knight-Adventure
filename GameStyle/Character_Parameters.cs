using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Parameters : MonoBehaviour
{
    [SerializeField] private GameObject _attackCount;
    [SerializeField] private GameObject _speedCount;
    [SerializeField] private GameObject _healthCount;
    private float _minDmg;
    private float _maxDmg;

    private void Update()
    {
        _minDmg = PlayerData.MinDmg + PlayerData.DmgUp * PlayerData.WeaponUpLvl;
        _maxDmg = PlayerData.MaxDmg + PlayerData.DmgUp * PlayerData.WeaponUpLvl;
        _attackCount.GetComponent<Text>().text = _minDmg + " - " + _maxDmg;
        _speedCount.GetComponent<Text>().text = PlayerData.AttakSpeed + "";
        _healthCount.GetComponent<Text>().text = PlayerData.HealthPoint + "/" + PlayerData.MaxHealth;
    }
}
