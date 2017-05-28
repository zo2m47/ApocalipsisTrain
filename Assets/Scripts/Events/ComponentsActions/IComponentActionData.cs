using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum EnumComponentAction
{
    wordTouch,
    wordClicked,
    wordDragging
}


public interface IComponentActionData
{
    EnumComponentAction ComponentAction { get; }
}
