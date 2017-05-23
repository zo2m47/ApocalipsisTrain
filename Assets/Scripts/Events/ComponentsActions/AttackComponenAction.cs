using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AttackComponenAction : IComponentAction
{
    private EnumComponentAction _action;
    public EnumComponentAction Action
    {
        get
        {
            return _action;
        }
    }
    public EnumComponentGroupAction GroupAction
    {
        get
        {
            return EnumComponentGroupAction.attack;
        }
    }

    //position in the world 
    private Vector3 _wordTouchedPosition;
    public Vector3 WordTouchedPosition{get{ return _wordTouchedPosition; }}

    public AttackComponenAction(EnumComponentAction action, Vector3 wordTouchedPosition)
    {
        _action = action;
        _wordTouchedPosition = wordTouchedPosition;
    }
}
