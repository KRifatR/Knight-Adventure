using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixture : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("WallColl"))
        {
            PlayerData.MixturesCount++;
            Destroy(gameObject);
        }
    }
}
