using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuSceneManager : MonoBehaviour
{

    public AudioClip buttonHItSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // get the audio aound compenent
        audioSrc= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1); // wait for 2 seconds
        SceneManager.LoadScene("HomeScreen");  // Go to the "HomeScreen" game scene

    }

    public void playGame()
    {
        // call the Wait IEnumerator
        StartCoroutine(Wait());

        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHItSound);
    }

    public void quitGame()
    {
        // quit the application
        Application.Quit();
        audioSrc.PlayOneShot(buttonHItSound);
    }

    public void loadGame()
    {
        StartCoroutine(Wait());

        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHItSound);
    }

    public void setting()
    {
        StartCoroutine(Wait());

        // play the button hit sound 
        audioSrc.PlayOneShot(buttonHItSound);
    }

}
