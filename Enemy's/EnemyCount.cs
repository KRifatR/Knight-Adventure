using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    private GameObject[] _enemy;
    private float _enemyCount;
    [SerializeField] private AudioSource _deathVoice;
    [SerializeField] private Text _enemyCountText;
    [SerializeField] private Text _dungeonLvlText;

    [SerializeField] private int _dungeonLvl;

    private void Start()
    {
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        _enemyCount = _enemy.Length;
    }
    void Update()
    {
        Dungeon.DungeonLvl = _dungeonLvl;
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        _enemyCountText.text = _enemyCount.ToString();
        _deathVoice.volume = PlayerData.SoundVolume * 0.5f;

        if (Dungeon.DungeonLvl < 1)
        {
            _dungeonLvlText.text = "1";
        }
        else
        {
            _dungeonLvlText.text = Dungeon.DungeonLvl.ToString();
        }

        if (_enemyCount != _enemy.Length)
        {
            _deathVoice.Play();
            _enemyCount = _enemy.Length;
        }
    }
}
