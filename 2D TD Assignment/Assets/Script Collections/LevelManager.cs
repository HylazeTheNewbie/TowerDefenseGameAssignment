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

    private void Awake()
    {
        main = this;

        // Find and store paths in a straightforward manner
        GameObject[] path1Objects = GameObject.FindGameObjectsWithTag("Path1");
        GameObject[] path2Objects = GameObject.FindGameObjectsWithTag("Path2");
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