using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject objectMusic;
    private AudioSource AudioSource;
    private float musicVolume = 1f;

    void Start()
    {
        objectMusic = GameObject.FindWithTag("Music");
        AudioSource = objectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void updateVolume (float volume) {
        musicVolume = volume;        
    }

    public void musicReset() {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 0.5F; //F means float
        volumeSlider.value = 0.5F;
    }
}
