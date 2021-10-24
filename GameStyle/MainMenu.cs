using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    [SerializeField] private GameObject _mainMenuBattons;
    [SerializeField] private GameObject _mainMenuBackground;

    [SerializeField] private GameObject _optionsBattons;
    [SerializeField] private GameObject _optionsBackground;

    private void Start()
    {
        _music.Play();

        _mainMenuBattons.SetActive(true);
        _mainMenuBackground.SetActive(true);

        _optionsBattons.SetActive(false);
        _optionsBackground.SetActive(false);

    }
    private void Update()
    {
        _music.GetComponent<AudioSource>().volume = PlayerData.MusicVolume;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        PlayerData.CoinCount = 0;
        PlayerData.MaxHealth = 100;
        PlayerData.HealthPoint = 100;
        PlayerData.LiveCount = 3;
        PlayerData.MinDmg = 15;
        PlayerData.MaxDmg = 25;
        PlayerData.AttakSpeed = 7;
        PlayerData.AttakInSecond = PlayerData.AttakSpeed / 2f;
        PlayerData.MixturesCount = 3;
        PlayerData.Score = 0;

        PlayerData.WeaponUpLvl = 0;

        PlayerData.PlayerSkin = 0;
        PlayerData.WeaponType = 0;

        PlayerData.Quest_1 = 0;
    }

    public void OpenOptions()
    {
        _mainMenuBattons.SetActive(false);
        _mainMenuBackground.SetActive(false);

        _optionsBattons.SetActive(true);
        _optionsBackground.SetActive(true);
    }

    public void MusicVolume(float musicVolume)
    {
        PlayerData.MusicVolume = musicVolume;
    }

    public void SoundVolume(float soundVolume)
    {
        PlayerData.SoundVolume = soundVolume;
    }

    public void BackInMainMenu()
    {
        _mainMenuBattons.SetActive(true);
        _mainMenuBackground.SetActive(true);

        _optionsBattons.SetActive(false);
        _optionsBackground.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
