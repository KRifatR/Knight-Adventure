using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour
{
    [SerializeField] private int[] _sceneIndex;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("WallColl"))
        {
            PlayerData.SoundVolume = 0;
            PlayerData.Score += PlayerData.LiveCount * 1000;
            SceneManager.LoadScene(_sceneIndex[Random.Range(0, _sceneIndex.Length)]);
            Destroy(gameObject);
        }
    }
}
