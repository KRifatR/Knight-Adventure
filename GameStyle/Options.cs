using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject _musicSlider;
    [SerializeField] private GameObject _soundSlider;
    private void Start()
    {
        _musicSlider.GetComponent<Slider>().value = PlayerData.MusicVolume;
        _soundSlider.GetComponent<Slider>().value = PlayerData.SoundVolume;
    }
    public void MusicVolume(float musicVolume)
    {
        PlayerData.MusicVolume = musicVolume;
    }

    public void SoundVolume(float soundVolume)
    {
        PlayerData.SoundVolume = soundVolume;
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }

    public void QuitInMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
