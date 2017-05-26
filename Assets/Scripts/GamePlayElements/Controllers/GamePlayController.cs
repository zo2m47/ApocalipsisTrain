using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GamePlayController : MonoBehaviour, IRecyle
{
    public delegate void InitStaticData();
    public InitStaticData initStaticData;
    /*
     * Static data 
     * */
    protected object _staticData;
    public virtual object StaticData
    {
        set
        {
            _staticData = value;
            if (initStaticData != null)
            {
                initStaticData();
            }
        }

        get
        {
            return _staticData;
        }
    }

    /*
     * IRecyle
     * */
    public virtual void Restart()
    {
        
    }

    public virtual void Shutdown()
    {
        
    }
}
