using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceCoins : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    private Text _coinCounter;

    void Start()
    {
        _coinCounter = _text.GetComponent<Text>();
    }
    void Update()
    {
        _coinCounter.text = PlayerData.CoinCount.ToString();
    }
}
