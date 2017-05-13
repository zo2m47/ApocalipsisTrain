using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{

    public RecycleGameObjectManager prefab;

    private List<RecycleGameObjectManager> poolInstances = new List<RecycleGameObjectManager>();

    private RecycleGameObjectManager CreateInstance()
    {

        var clone = GameObject.Instantiate(prefab);
        clone.transform.SetParent(transform);

        poolInstances.Add(clone);

        return clone;
    }

    public RecycleGameObjectManager NextObject()
    {
        RecycleGameObjectManager instance = null;

        foreach (var go in poolInstances)
        {
            if (!go.gameObject.active)
            {
                instance = go;
                break;
            }
        }

        if (instance == null)
            instance = CreateInstance();

        instance.Restart();

        return instance;
    }

}
