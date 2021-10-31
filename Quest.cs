using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject _dialogWindow;
    [SerializeField] private GameObject _text1;
    [SerializeField] private GameObject _text2;
    [SerializeField] private GameObject _text3;

    [SerializeField] private GameObject _blockLvL1;
    [SerializeField] private GameObject _blockLvL2;
    [SerializeField] private GameObject _minimapBlockLvl1;
    [SerializeField] private GameObject _minimapBlockLvl2;
    private void Start()
    {
        if (PlayerData.Quest_1 == 1)
        {
            Destroy(_blockLvL1);
            _minimapBlockLvl1.SetActive(true);
        }
        else if (PlayerData.Quest_1 == 2)
        {
            Destroy(_blockLvL1);
            _minimapBlockLvl1.SetActive(true);
            Destroy(_blockLvL2);
            _minimapBlockLvl2.SetActive(true);
        }
        else
        {
            _minimapBlockLvl1.SetActive(false);
            _minimapBlockLvl2.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && PlayerData.Quest_1 == 0)
        {
            _dialogWindow.SetActive(true);
            _text1.SetActive(true);
            _text2.SetActive(false);
            _text3.SetActive(false);
        }
        else if (collision.tag.Equals("Player") && PlayerData.Quest_1 == 1)
        {
            _dialogWindow.SetActive(true);
            _text1.SetActive(false);
            _text2.SetActive(false);
            _text3.SetActive(true);
        }
        else if (collision.tag.Equals("Player") && PlayerData.Quest_1 == 2)
        {
            _dialogWindow.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") &&  _dialogWindow.activeInHierarchy == true &&  _text1.activeInHierarchy == true && Input.GetKey(KeyCode.E) && _blockLvL2 != null )
        {
            _text1.SetActive(false);
            _text2.SetActive(true);
            _text3.SetActive(false);
        }
        else if (collision.tag.Equals("Player") && _dialogWindow.activeInHierarchy == true && _text2.activeInHierarchy == true && Input.GetKey(KeyCode.Tab) && _blockLvL2 != null)
        {
            Destroy(_blockLvL1);
            _minimapBlockLvl1.SetActive(true);
            _dialogWindow.SetActive(false);
        }
        else if (collision.tag.Equals("Player") && _dialogWindow.activeInHierarchy == true && _text3.activeInHierarchy == true && Input.GetKey(KeyCode.Tab) && _blockLvL2 != null)
        {
            PlayerData.Quest_1 = 2;

            PlayerData.PlayerSkin = 1;
            PlayerData.WeaponUpLvl += 1;
            PlayerData.MaxHealth += 20;
            PlayerData.HealthPoint = PlayerData.MaxHealth;
            PlayerData.CoinCount += 500;

            if(PlayerData.WeaponType == 0)
            {
                PlayerData.WeaponType = 1;
                PlayerData.AttakSpeed -= 1;
            }

            Destroy(_blockLvL2);
            _minimapBlockLvl2.SetActive(true);
            _dialogWindow.SetActive(false);
        }

    }
}
