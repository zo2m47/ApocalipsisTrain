using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    private object _data;
    public object Data
    {
        get
        {
            return _data;
        }
    }

    public EnumComponentGroupAction GroupAction
    {
        get
        {
            return EnumComponentGroupAction.attack;
        }
    }

    public AttackComponenAction(EnumComponentAction action, object data)
    {
        _action = action;
        _data = data;
    }
}
