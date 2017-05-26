using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AttackComponenAction : IComponentActionData
{
    
    //position in the world 
    private Vector3 _wordTouchedPosition;
    public Vector3 WordTouchedPosition{get{ return _wordTouchedPosition; }}

    public EnumComponentAction Action
    {
        get
        {
            return EnumComponentAction.attack;
        }
    }

    public AttackComponenAction(Vector3 wordTouchedPosition)
    {
        _wordTouchedPosition = wordTouchedPosition;
    }
}
