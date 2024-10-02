using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public static EnemyPathing main;
    public Transform startPoint;
    public List<Transform> path1;
    public List<Transform> path2;

    private GameObject[] waypoints1;
    private GameObject[] waypoints2; 
    private void Awake()
    {
        main = this;

        path1 = new List<Transform>();
        path2 = new List<Transform>();
        // Find and store paths in a straightforward manner
        waypoints1 = GameObject.FindGameObjectsWithTag("Path1");
        waypoints2 = GameObject.FindGameObjectsWithTag("Path2");

        InitializeTransformList();
    }

    public void InitializeTransformList()
    {
        foreach (GameObject waypoint in waypoints1)
        {
            path1.Add(waypoint.transform);
        }

        foreach (GameObject waypoint in waypoints2)
        {
            path2.Add(waypoint.transform);
        }
    }
}
