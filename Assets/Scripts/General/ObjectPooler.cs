﻿// * ObjectPooler.cs
// * AUTHOR: Rica Feng
// * DESCRIPTION:
// *    Helper for pooling objects. This is much faster than instantiating and destroying objects.
// * REQUIREMENTS:
// *    Attach anywhere.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    /// <summary>
    /// What object are we pooling?
    /// </summary>
    public GameObject ObjToPool;

    /// <summary>
    /// How many copies should we start with?
    /// </summary>
    [SerializeField]
    private int NumberOfCopies;

    /// <summary>
    /// Where to store pooled objects?
    /// </summary>
    [SerializeField]
    private Transform _StorageArea;
    public Transform StorageArea
    {
        get { return _StorageArea; }
        private set { _StorageArea = value; }
    }

    /// <summary>
    /// Number of these objects active
    /// </summary>
    public int NumberOfActiveObjects
    {
        get
        {
            int count = 0;
            foreach (GameObject obj in PooledObjects)
            {
                if (obj.activeInHierarchy)
                {
                    count++;
                }
            }
            return count;
        }
    }

    private List<GameObject> PooledObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < NumberOfCopies; ++i)
        {
            GameObject new_obj = AddObjToPool();
            new_obj.SetActive(false);
        }
    }

    /// <summary>
    /// Retrieve
    /// </summary>
    public GameObject RetrieveCopy()
    {
        foreach (GameObject obj in PooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        //All objects are currently in use, so create another.
        GameObject new_obj = AddObjToPool();
        new_obj.SetActive(true);
        return new_obj;
    }

    /// <summary>
    /// Set active to false for all pooled objects
    /// </summary>
    public void DeactivateAll()
    {
        foreach (GameObject obj in PooledObjects)
        {
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Create a new obj, add to storage area and to the list. Return the new obk
    /// </summary>
    private GameObject AddObjToPool()
    {
        GameObject copy = Instantiate(ObjToPool) as GameObject;
        copy.transform.SetParent(StorageArea, false);
        PooledObjects.Add(copy);
        return copy;
    }

}
