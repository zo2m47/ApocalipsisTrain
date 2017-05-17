using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MainScreenNavigationController : BaseUINavigationController
{
    public override EnumUIScreenID ScreenID
    {
        get
        {
            return EnumUIScreenID.main;
        }
    }
}
