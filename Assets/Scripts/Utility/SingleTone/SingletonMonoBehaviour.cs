using System;
using UnityEngine;
/**
 * uses to controlling singletone of classes
 * */

public class SingletonMonoBehaviour<T> : MonoBehaviourForSingleTone where T : SingletonMonoBehaviour<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    _instance = SingletonMonoBehaviourInstance<T>();
                }
            }
            return _instance;
        }
    }
    // Parent game object name 
    public virtual string gameObjecName
    {
        get
        {
            return "";
        }
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
