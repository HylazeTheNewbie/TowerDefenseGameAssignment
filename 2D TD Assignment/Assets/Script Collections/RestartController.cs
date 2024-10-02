using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    public AudioClip buttonHItSound;
    static AudioSource audioSrc;



    // Start is called before the first frame update
    void Start()
    {
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

    public void RestartGame()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        Debug.Log("Button hit sound played");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void BackToHome()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        SceneManager.LoadScene("MainMenu");
    }
}