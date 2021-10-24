using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private GameObject _scoreText;

    private void Start()
    {
        _music.volume = PlayerData.MusicVolume;
        _music.Play();
        _scoreText.GetComponent<Text>().text = PlayerData.Score + ""; 
    }
    public void QuitInMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
