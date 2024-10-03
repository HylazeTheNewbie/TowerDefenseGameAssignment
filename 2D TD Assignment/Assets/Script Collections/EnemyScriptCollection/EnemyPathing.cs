using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public static EnemyPathing main;

    public Transform startPoint;
    public List<Transform> path1;
    public List<Transform> path2;

    void Awake()
    {
        main = this;

        GameObject[] goPath1 = GameObject.FindGameObjectsWithTag("Path1");
        GameObject[] goPath2 = GameObject.FindGameObjectsWithTag("Path2");
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
