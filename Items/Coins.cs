using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int _min;
    [SerializeField] private int _max;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("WallColl"))
        {
            PlayerData.CoinCount += Random.Range(_min, _max * Dungeon.DungeonLvl);
            Destroy(gameObject);
        }
    }
}
