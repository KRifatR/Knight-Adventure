using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    [SerializeField] private int _weaponType;
    [SerializeField] private float _minDmg;
    [SerializeField] private float _maxDmg;
    [SerializeField] private float _attackSpeed;
    private GameObject _player;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerData.WeaponType = _weaponType;
            if (PlayerData.MinDmg < _minDmg)
            {
                PlayerData.MinDmg = _minDmg + PlayerData.WeaponUpLvl * PlayerData.DmgUp;
            }
            if (PlayerData.MaxDmg < _maxDmg)
            {
                PlayerData.MaxDmg = _maxDmg + PlayerData.WeaponUpLvl * PlayerData.DmgUp;
            }
            if (PlayerData.AttakSpeed < _attackSpeed)
            {
                PlayerData.AttakSpeed = _attackSpeed;
            }
            Destroy(gameObject);
        }
    }
}
