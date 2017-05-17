using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GamePlayScreenNavigationController : BaseUINavigationController
{
    public override EnumUIScreenID ScreenID
    {
        get
        {
            return EnumUIScreenID.gamePlay;
        }
    }
}
