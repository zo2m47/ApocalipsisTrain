﻿using System;

public enum EnumMoveAction
{
    wait,
    start,
    faster,
    slower,
    stop
}

public class MoveAction : IComponentActionData
{
    private EnumMoveAction _action;
}
