using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;       // R�f�rence au slider
    public AudioSource audioSource;  // R�f�rence � l'AudioSource

    void Start()
    {
        // Charger la valeur du volume enregistr�e ou utiliser 0.5 par d�faut
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        if (audioSource != null && volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }
    }

    void UpdateVolume(float value)
    {
        if (audioSource != null)
        {
            audioSource.volume = value;
            PlayerPrefs.SetFloat("MusicVolume", value); // Enregistrer la nouvelle valeur
        }
    }
}
