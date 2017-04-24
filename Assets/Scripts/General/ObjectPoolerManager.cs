using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerManager : Singleton<ObjectPoolerManager>
{
    private Dictionary<string, ObjectPooler> _GetPooler = new Dictionary<string, ObjectPooler>();

    /// <summary>
    /// Index by the Celest that you want
    /// </summary>
    public Dictionary<string, ObjectPooler> GetPooler
    {
        get { return _GetPooler; }
        private set { _GetPooler = value; }
    }

    private void Awake()
    {
        ObjectPooler[] all_poolers = transform.GetComponentsInChildren<ObjectPooler>();
        for (int i = 0; i < all_poolers.Length; ++i)
        {
            if (all_poolers[i].ObjToPool != null)
            {
                CelestialBody body = all_poolers[i].ObjToPool.GetComponent<CelestialBody>();
                if (body != null && !GetPooler.ContainsKey(body.GetCelest().name))
                {
                    //print("adding " + body.GetCelest().name + " to pooler.");
                    GetPooler.Add(body.GetCelest().name, all_poolers[i]);
                }
            }          
        }
    }
    
}
