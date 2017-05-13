
/*
 * Singletone class logic of conection
 * */
using System;
using UnityEngine;
public class ManagerSingleTone<T> : SingletonMonoBehaviour<T> where T : ManagerSingleTone<T>
{
    public override string gameObjecName
    {
        get
        {
            return MANAGER_OBJECT_NAME;
        }
    }
}

