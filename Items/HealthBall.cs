using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBall : MonoBehaviour
{
    [SerializeField] private int _min;
    [SerializeField] private int _max;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerData.HealthPoint += Random.Range(_min, _max);
            Destroy(gameObject);
        }
    }
}
