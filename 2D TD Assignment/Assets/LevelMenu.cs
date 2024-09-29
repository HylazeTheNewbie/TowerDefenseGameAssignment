using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string leve1Name = "CampaignLev1" + levelId;
        SceneManager.LoadScene("CampaignLev1");
    }
}
