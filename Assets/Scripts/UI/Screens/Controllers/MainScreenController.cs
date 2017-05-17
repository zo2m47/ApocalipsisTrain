using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MainScreenController : BaseUIScreenController, IGamePlayScreenDataProvider
{
    public override string ClassNameInInitialization
    {
        get
        {
            return "Main Screen Controller";
        }
    }

    public override EnumUIScreenID screenID
    {
        get
        {
            return EnumUIScreenID.main;
        }
    }
}
