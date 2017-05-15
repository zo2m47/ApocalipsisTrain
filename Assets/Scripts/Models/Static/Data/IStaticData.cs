using System;
using System.Collections.Generic;

public interface IStaticData
{
    EnumStaticDataType Type { get; }
    string Name{ get; }
}
