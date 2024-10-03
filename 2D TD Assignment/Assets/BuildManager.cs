using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    SoundManager audioManager;

    [Header("References")]
    [SerializeField] private SelectTower[] towers;

    private int selectedTower = 0;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        main = this;
    }

    public SelectTower GetSelectedTower()
    {
        audioManager.PlaySFX(audioManager.placeTower);
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        audioManager.PlaySFX(audioManager.placeTower);
        selectedTower = _selectedTower;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
