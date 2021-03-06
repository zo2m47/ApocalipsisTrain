﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocomotiveViewManager : MonoBehaviour
{
    private GameObject _container;
    private TrainGamePlayController _trainGameController;
    private List<CarriageGamePlayController> _carriageList = new List<CarriageGamePlayController>();

    private float _height;
    public float Height
    {
        get
        {
            return _height;
        }
    }

    private void Start()
    {
        _container = gameObject;
    }

    public void Init()
    {
        CleanLocomotive();
        //creat instance of train
        _trainGameController = PrefabCreatorManager.Instance.InstanceComponent<TrainGamePlayController>(TrainStaticData.PrefabUrl, _container);
        _trainGameController.StaticData = TrainStaticData;
        _height = 0;
        _height += _trainGameController.Height;
        //crat instance of carrieages 
        _carriageList = new List<CarriageGamePlayController>();
        List<CarriageVO> carriageDataList = CarriageStaticDataList;
        for (int i = 0;i< carriageDataList.Count;i++)
        {
            if (i == 0)
            {
                _carriageList.Add(PrefabCreatorManager.Instance.InstanceComponent<CarriageGamePlayController>(carriageDataList[i].PrefabUrl, _trainGameController.Connector, EnumPositioning.local, new Vector3(0, 0, 0)));
            } else
            {
                _carriageList.Add(PrefabCreatorManager.Instance.InstanceComponent<CarriageGamePlayController>(carriageDataList[i].PrefabUrl, _carriageList[_carriageList.Count-1].Connector, EnumPositioning.local, new Vector3(0,0,0)));
            }
            _carriageList[_carriageList.Count - 1].StaticData = carriageDataList[i];
            _height += _carriageList[_carriageList.Count - 1].Height;
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
            return MainGameController.Instance.LocomotiveData.Train;
        }
    }

    private List<CarriageVO> CarriageStaticDataList
    {
        get
        {
            return MainGameController.Instance.LocomotiveData.CarriageList;
        }
    }
}
