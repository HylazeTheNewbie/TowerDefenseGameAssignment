using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeScreenEvent : MonoBehaviour
{
    //pass the level selection into paramete
   public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);

    }


    public void BackToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
