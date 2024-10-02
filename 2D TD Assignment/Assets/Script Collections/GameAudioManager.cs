using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; //for the volume
    [SerializeField] Button soundOnIcon;
    [SerializeField] Button soundOffIcon;
    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        else
        {
            Load();
        }

        // for the sound 
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0); // for the default setting for the sound
            Load();
        }
        else
        {
            Load(); // save the data from the previes one 
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }



    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    // for the sound button on and off 
    public void onButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }



    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        //get the interger value we save it 
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetInt("muted", muted ? 1 : 0); // trun the boolean into integer value // if the muted is true we will save it = 1, else... 
    }



}
