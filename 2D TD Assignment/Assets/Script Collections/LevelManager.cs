using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform startPoint;
    public List<Transform> path1;
    public List<Transform> path2;

    public int currency;

    private void Start()
    {
        currency = 100;
    }

    public void increaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You dont have enough money to buy this tower");
            return false;
        }
    }


    private void Awake()
    {
        main = this;

        // Find and store paths in a straightforward manner
        GameObject[] waypoints1 = GameObject.FindGameObjectsWithTag("Path1");
        GameObject[] waypoints2 = GameObject.FindGameObjectsWithTag("Path2");
    }

    public List<Transform> GetPathByTag(string tag)
    {
        switch (tag)
        {
            case "Path1":
                return path1;
            case "Path2":
                return path2;
            default:
                return null;
        }
    }
}