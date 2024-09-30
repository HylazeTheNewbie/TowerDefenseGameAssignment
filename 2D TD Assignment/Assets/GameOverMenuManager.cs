using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    public AudioClip buttonHitSound;
    static AudioSource audioSrc;

    void Start()
    {
        // get the audio source component
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }
    }


    public void gameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void Home()
    {
        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHitSound);

        // Wait for the sound to finish playing before loading the scene
        StartCoroutine(LoadSceneAfterSound("MainMenu"));
    }

    public void Replay()
    {
        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHitSound);

        // Wait for the sound to finish playing before reloading the scene
        StartCoroutine(LoadSceneAfterSound("CampaignLev1"));

        // Reload the current scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    IEnumerator LoadSceneAfterSound(string sceneName)
    {
        // Debug log to ensure the coroutine is executing
        Debug.Log("Loading scene: " + sceneName);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
        // Wait until the audio has finished playing
        while (audioSrc.isPlaying)
        {
            yield return null;
        }


    }



    }