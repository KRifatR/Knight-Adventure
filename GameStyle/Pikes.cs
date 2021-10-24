using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikes : MonoBehaviour
{
    [SerializeField] private int _minDmg;
    [SerializeField] private int _maxDmg;
    [SerializeField] private float _dmgTick;
    private bool _dmg = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            _dmg = true;
            StartCoroutine(PerDmg());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            _dmg = false;
            StopCoroutine(PerDmg());
        }
    }

    IEnumerator PerDmg()
    {
        for (int i = 0; _dmg == true; i++)
        {
            PlayerData.HealthPoint -= Random.Range(_minDmg, _maxDmg);
            yield return new WaitForSeconds(_dmgTick);
        }
    }
}
