using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum EnumComponentAction
{
    attack
}


public interface IComponentActionData
{
    EnumComponentAction Action { get; }
}
