
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GamePlayScreenController : BaseUIScreenController, IMainScreenDataProvider
{
    public override string ClassNameInInitialization
    {
        get
        {
            return "Game Play Screen Controller";
        }
    }

    public override EnumUIScreenID screenID
    {
        get
        {
            return EnumUIScreenID.gamePlay;
        }
    }

    public override void SetData(object data)
    {
        base.SetData(data);
        GamePlayModel.Instance.PrepareTrain();
        GameViewManager.Instance.ShowGamePlayView();
    }
}
