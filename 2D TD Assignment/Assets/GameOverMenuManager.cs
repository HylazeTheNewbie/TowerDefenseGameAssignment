using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    public AudioClip buttonHItSound;
    static AudioSource audioSrc;

    void Start()
    {
        // get the audio aound compenent
        audioSrc = GetComponent<AudioSource>();
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void Home()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        SceneManager.LoadScene("HomeScreen");

    }

    public void Replay()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        SceneManager.LoadScene("CampaignLev1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
