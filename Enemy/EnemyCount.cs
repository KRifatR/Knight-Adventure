using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    private GameObject[] _enemy;
    private float _enemyCount;
    [SerializeField] private Text _enemyCountText;
    [SerializeField] private Text _dungeonLvlText;

    [SerializeField] private int _dungeonLvl;
    void Update()
    {
        Dungeon.DungeonLvl = _dungeonLvl;

        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        _enemyCount = _enemy.Length;
        _enemyCountText.text = _enemyCount.ToString();
        _dungeonLvlText.text = Dungeon.DungeonLvl.ToString();
    }
}
