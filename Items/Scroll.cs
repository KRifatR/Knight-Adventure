using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour
{
    [SerializeField] private int[] _sceneIndex;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            PlayerData.SoundVolume = 0;
            PlayerData.Score += PlayerData.LiveCount * 1000;
            SceneManager.LoadScene(_sceneIndex[Random.Range(0, _sceneIndex.Length)]);
            Destroy(gameObject);
        }
    }
}
