
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreenController : BaseUIScreenController, IMainScreenDataProvider
{
    [SerializeField]
    private UIButton _upTransmisionButton;
    [SerializeField]
    private UIButton _downTransmisionButton;
    [SerializeField]
    private Text _tfTransmisionIndex;

    private int _selectedTransmision = 0;
    private List<TransmissionData> _transmisionList;
    private void Start()
    {
        if (_upTransmisionButton!=null)
        {
            _upTransmisionButton.Selected += UpTransmisionClicked;
        }

        if (_downTransmisionButton != null)
        {
            _downTransmisionButton.Selected += DownTransmisionClicked;
        }
    }

    /*
     * Change transmision
     * */   
    private void UpTransmisionClicked(object data, EventArgs args)
    {
        _selectedTransmision++;
        UpdateTranSmition();
    }

    private void DownTransmisionClicked(object data, EventArgs args)
    {
        _selectedTransmision--;
        UpdateTranSmition();
    }

    private void UpdateTranSmition()
    {
        _tfTransmisionIndex.text = _transmisionList[_selectedTransmision].index.ToString();
        _upTransmisionButton.Enabled = _selectedTransmision < _transmisionList.Count - 1;
        _downTransmisionButton.Enabled = _selectedTransmision > 0;

        MainGameController.Instance.SelecttransmisionByListPosition(_selectedTransmision);
    }

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
        MainGameController.Instance.StartGame();

        //set transmision settings 
        _selectedTransmision = 0;
        _transmisionList = MainGameController.Instance.LocomotiveData.Train.SortedTransmissionList;
        UpdateTranSmition();
    }
}
