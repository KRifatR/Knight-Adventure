using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventar : MonoBehaviour
{
    [SerializeField] private GameObject _mixturesCount;
    void Update()
    {
        _mixturesCount.GetComponent<Text>().text = PlayerData.MixturesCount + "";

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseMixture();
        }
    }

    public void UseMixture()
    {
        if (PlayerData.MixturesCount > 0)
        {
            PlayerData.MixturesCount = PlayerData.MixturesCount - 1;
            PlayerData.HealthPoint = PlayerData.HealthPoint + PlayerData.MaxHealth*3/4;
        }
        else if (PlayerData.MixturesCount == 0)
        {
            PlayerData.MixturesCount = 0;
        }
    }
}
