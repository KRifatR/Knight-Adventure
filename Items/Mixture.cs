using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixture : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerData.MixturesCount++;
            Destroy(gameObject);
        }
    }
}
