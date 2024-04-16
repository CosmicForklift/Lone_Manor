using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider SoundSlider;
    void Start()
    {

        if (!PlayerPrefs.HasKey("Volume")) 
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }

   public void ChangeVolume()
    {
        AudioListener.volume = SoundSlider.value;
        Save();
    }

    private void Load()
    {
        SoundSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save() 
    {
        PlayerPrefs.SetFloat("Volume",SoundSlider.value);
    }
}
