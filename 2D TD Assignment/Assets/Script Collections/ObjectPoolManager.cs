using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    public static GameObject SpawnObject(GameObject objectToSpawn,
        Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = null;

        foreach (PooledObjectInfo p in ObjectPools)
        {
            if (p.LookupString == objectToSpawn.name)
            {
                pool = p;
                break;
            }
        }

        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        GameObject spawnableObjects = null;

        foreach (GameObject obj in pool.InactiveObjects)
        {
            if (obj != null)
            {
                spawnableObjects = obj;
                break;
            }
        }

        if (spawnableObjects == null)
            spawnableObjects = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        else
        {
            spawnableObjects.transform.position = spawnPosition;
            spawnableObjects.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObjects);
            spawnableObjects.SetActive(true);
        }

        return spawnableObjects;
    }

    public static void ReturnToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);

        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled : " + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);  
        }
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
