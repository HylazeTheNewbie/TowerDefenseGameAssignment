using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    SoundManager audioManager;

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        audioManager.PlaySFX(audioManager.placeTower);
        SelectTower towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
