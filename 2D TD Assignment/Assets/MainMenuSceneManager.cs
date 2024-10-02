using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MainMenuSceneManager : MonoBehaviour
{

    public AudioClip buttonHItSound;
    static AudioSource audioSrc;
    //public Slider volumeSlider;                   // need to done this after the map is complete
    //public AudioMixer mixer;

    //public void setVolume()
    //{
    //    mixer.SetFloat("VolumeMainMenu", volumeSlider.value);
    //}

    // Start is called before the first frame update
    void Start()
    {
        // get the audio source component
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IEnumerator WaitAndLoadScene()
    //{
    //    yield return new WaitForSeconds(0.1f); // Wait for a short time to ensure the sound plays
    //    SceneManager.LoadScene("CampaignLev1");  // Go to the "CampaignLev1" game scene

    //}

    public void playGame()
    {
        Debug.Log("playGame method called");
        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHItSound);
        Debug.Log("Button hit sound played");

        // Wait for a short time before loading the next scene
        //StartCoroutine(WaitAndLoadScene());
    }

    public void quitGame()
    {
        // quit the application
        Application.Quit();
        audioSrc.PlayOneShot(buttonHItSound);
    }

    public void setting()
    {
        //StartCoroutine(Wait());

        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHItSound);
    }

}
