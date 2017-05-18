﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocomotiveViewManager : MonoBehaviour
{
    private GameObject _container;
    private TrainGameController _trainGameController;
    private List<CarriageGameController> _carriageList = new List<CarriageGameController>();

    private void Start()
    {
        _container = gameObject;
    }

    public void Init()
    {
        CleanLocomotive();
        //creat instance of train
        _trainGameController = PrefabCreatorManager.Instance.InstanceComponent<TrainGameController>(TrainStaticData.PrefabUrl, _container);
        //crat instance of carrieages 
        _carriageList = new List<CarriageGameController>();
        List<CarriageVO> carriageDataList = CarriageStaticDataList;
        for (int i = 0;i< carriageDataList.Count;i++)
        {
            if (i == 0)
            {
                _carriageList.Add(PrefabCreatorManager.Instance.InstanceComponent<CarriageGameController>(carriageDataList[i].PrefabUrl, _trainGameController.Connector, EnumPositioning.local, new Vector3(0, 0, 0)));
            } else
            {
                _carriageList.Add(PrefabCreatorManager.Instance.InstanceComponent<CarriageGameController>(carriageDataList[i].PrefabUrl, _carriageList[_carriageList.Count-1].Connector, EnumPositioning.local, new Vector3(0,0,0)));
            }
        }
    }
    /// <summary>
    /// Remove prefab of train and all carriegaes
    /// </summary>
    private void CleanLocomotive()
    {
        if (_trainGameController)
        {
            PrefabCreatorManager.Instance.DestroyPrefab(_trainGameController.gameObject);
        }

        for (int i =0;i<_carriageList.Count;i++)
        {
            PrefabCreatorManager.Instance.DestroyPrefab(_carriageList[i].gameObject);
        }
        _carriageList.Clear();
    }

    private TrainVO TrainStaticData
    {
        get
        {
            return GamePlayModel.Instance.LocomotiveSettings.Train;
        }
    }

    private List<CarriageVO> CarriageStaticDataList
    {
        get
        {
            return GamePlayModel.Instance.LocomotiveSettings.CarriageList;
        }
    }
}