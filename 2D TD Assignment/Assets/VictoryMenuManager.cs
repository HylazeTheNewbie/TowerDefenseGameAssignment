using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuManager : MonoBehaviour
{
    public AudioClip buttonHItSound;
    static AudioSource audioSrc;

    public static VictoryMenuManager instance;

    public static int lastLevelIndex;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void restart()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        Debug.Log("Button hit sound played");


        if (lastLevelIndex != 0) // Ensure the last level was set
        {
            SceneManager.LoadSceneAsync(lastLevelIndex); // Reload the stored level
        }
        else
        {
            Debug.LogError("Last level index not set.");
        }
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



    public void home()
    {
        audioSrc.PlayOneShot(buttonHItSound);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayerWin()
    {
        lastLevelIndex = SceneManager.GetActiveScene().buildIndex; // Store the current level index
        SceneManager.LoadScene("WinGameScreen"); // Load the win scene
    }

    // Call this method when the player loses
    public void OnPlayerLose()
    {
        lastLevelIndex = SceneManager.GetActiveScene().buildIndex; // Store the current level index
        SceneManager.LoadScene("GameOver"); // Load the lose scene
    }

}
