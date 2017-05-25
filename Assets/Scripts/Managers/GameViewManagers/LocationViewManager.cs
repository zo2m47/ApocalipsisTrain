using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocationViewManager : MonoBehaviour
{
    private const int CountOfParts = 3;
    private float _speed = 0;
    private List<LocationBgController> _locationPartList = new List<LocationBgController>();
    /**
     * need to initializate all prefabs of Location bg and railway parts, for cach
     * */
    private void InitAllLocationParts()
    {

    }

    private void InitAllRaiWayParts()
    {

    }

    public void InitLocationParts()
    {
        LocationBgController locationPart;
        float verticalPosition = 0;
        for (int i = 0; i < CountOfParts;i++)
        {
            locationPart = PrefabCreatorManager.Instance.InstanceComponent<LocationBgController>(PrefabsURL.GAMEPLAY_LOCATION_PARTS_GAME_ELEMENT + "GamePlayLocationPart_1", gameObject);
            if (i!=0)
            {
                verticalPosition += locationPart.Height;
            }
            locationPart.gameObject.transform.position = new Vector3(0, verticalPosition, 0);
            _locationPartList.Add(locationPart);
        }
        StartMove(MainGameController.Instance.SelectedTransmission.speed);
    }

    public void StartMove(float speed)
    {
        _speed = speed;
    }

    void Update()
    {
        if (_speed != 0)
        {
            gameObject.transform.Translate(Vector3.down * (Time.deltaTime * _speed));
            if (_locationPartList[0].gameObject.transform.position.y< -1*_locationPartList[0].Height)
            {
                float yPosition = _locationPartList[_locationPartList.Count - 1].gameObject.transform.position.y;
                _locationPartList[0].gameObject.transform.position = new Vector3(0, _locationPartList[0].Height + yPosition,0);
                _locationPartList.Add(_locationPartList[0]);
                _locationPartList.RemoveAt(0);
            }
        }
    }
}
