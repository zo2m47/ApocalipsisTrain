using System;
using System.Collections.Generic;
using UnityEngine;

public class WordComponentActionData : IComponentActionData
{
    private EnumComponentAction _componentAction;
    public EnumComponentAction ComponentAction
    {
        get
        {
            return _componentAction;
        }
    }

    //position in the world 
    private Vector3 _wordTouchedPosition;
    public Vector3 WordTouchedPosition { get { return _wordTouchedPosition; } }


    public WordComponentActionData(EnumComponentAction componentAction, Vector3 wordTouchedPosition)
    {
        _componentAction = componentAction;
        _wordTouchedPosition = wordTouchedPosition;
    }
}
