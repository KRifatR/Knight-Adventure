using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource[] _music;
    private int _playMusic;
   
    private void FixedUpdate()
    {
        _playMusic = 0;
        for (int i = 0; i < _music.Length; i++)
        {
            if (_music[i].isPlaying == true)
            {
                _playMusic++;
            }
            _music[i].GetComponent<AudioSource>().volume = PlayerData.MusicVolume;
        }
        if (_playMusic == 0)
        {
            _music[Random.Range(0, _music.Length)].Play();
        }
    }
}
