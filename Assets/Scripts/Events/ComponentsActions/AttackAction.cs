using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum EnumAttackAction
{
    shooting,
    reload,
    cooldawn
}

public class AttackAction : IComponentActionData
{
    private EnumMoveAction _action;
}
