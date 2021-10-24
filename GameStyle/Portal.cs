using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int[] _sceneIndex;
    [SerializeField] private GameObject _loadingImage;
    [SerializeField] private AudioSource _runSound;
   
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            _runSound.volume = 0;
            _loadingImage.SetActive(true);
            SceneManager.LoadScene(_sceneIndex[Random.Range(0, _sceneIndex.Length)]);
        }
    }
}
