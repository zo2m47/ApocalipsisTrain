﻿using System.Collections.Generic;
using UnityEngine;

public class PrefabCreatorManager : ManagerSingleTone<PrefabCreatorManager>
{
    private Dictionary<RecycleGameObjectManager, ObjectPoolManager> _pools = new Dictionary<RecycleGameObjectManager, ObjectPoolManager>();
    private GameObject _gameObjectsPool;

    private Dictionary<string, GameObject> _loadedGameObjectsPool = new Dictionary<string, GameObject>();

    //creat prefab 
    public GameObject InstanceOfPrefab(string prefabUrl, GameObject container = null, bool withPositionSetter = true, Vector3 pos = default(Vector3))
    {
        //try to load prefab from resources folder 
        if (!_loadedGameObjectsPool.ContainsKey(prefabUrl))
        {
            //save loaded prefab in pool
            _loadedGameObjectsPool[prefabUrl] = Resources.Load(prefabUrl, typeof(GameObject)) as GameObject;
        }

        GameObject go = _loadedGameObjectsPool[prefabUrl];
        if (go == null)
        {
            LoggingManager.AddErrorToLog("Didnt found prefab " + prefabUrl);
        }
        //try get RecycleGameObjectController, if it, so get it frome pool
        var recycledScript = go.GetComponent<RecycleGameObjectManager>();
        GameObject instance = null;

        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject().gameObject;
        }
        else
        {
            //creat brefab instance
            instance = Instantiate(go) as GameObject;
        }

        if (container != null)
        {
            //add prefab to container
            instance.transform.SetParent(container.transform);
        }
        if (withPositionSetter)
        {
            instance.transform.position = pos;
        }
        return instance;
    }

    private ObjectPoolManager GetObjectPool(RecycleGameObjectManager reference)
    {
        ObjectPoolManager pool = null;

        if (_pools.ContainsKey(reference))
        {
            pool = _pools[reference];
        }
        else
        {
            if (_gameObjectsPool == null)
            {
                _gameObjectsPool = new GameObject("GameObjectsPool");
            }
            GameObject poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            poolContainer.layer = reference.gameObject.layer;
            poolContainer.transform.parent = _gameObjectsPool.transform;
            pool = poolContainer.AddComponent<ObjectPoolManager>();
            pool.prefab = reference;
            _pools.Add(reference, pool);
        }

        return pool;
    }
    //destroy prefab 
    public void DestroyPrefab(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return;
        }

        var recyleGameObject = gameObject.GetComponent<RecycleGameObjectManager>();

        if (recyleGameObject != null)
        {
            recyleGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    //return component from created prefab 
    public CMP InstanceComponent<CMP>(string prefabUrl, GameObject container = null, bool withPositionSetter = true, Vector3 pos = default(Vector3)) where CMP : class
    {
        CMP returnClass = InstanceOfPrefab(prefabUrl, container, withPositionSetter,pos).GetComponent(typeof(CMP)) as CMP;
        if (returnClass == null)
        {
            LoggingManager.AddErrorToLog("Didnt found component " + typeof(CMP) + " in prefab " + prefabUrl);
        }
        return returnClass;
    }
}