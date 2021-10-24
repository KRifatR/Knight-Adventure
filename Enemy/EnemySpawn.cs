using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;

    private void Awake()
    {
        Instantiate(_enemy[Random.Range(0, _enemy.Length)], transform.position, Quaternion.identity);
    }
}
