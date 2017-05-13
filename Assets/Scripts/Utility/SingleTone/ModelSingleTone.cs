using System;
using System.Collections.Generic;
using UnityEngine;
public class ModelSingleTone<T> : SingletonMonoBehaviour<T> where T : ModelSingleTone<T>
{
    public override string gameObjecName
    {
        get
        {
            return MODEL_OBJECT_NAME;
        }
    }
}
