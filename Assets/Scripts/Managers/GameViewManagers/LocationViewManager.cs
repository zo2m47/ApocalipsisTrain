using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocationViewManager : MonoBehaviour
{
    private const int CountOfParts = 3;
    private float _speed = 0;

    private float _acceleration = 0;
    private float _braking = 0;

    private List<LocationBgController> _locationPartList = new List<LocationBgController>();
    private bool _moving = false;
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
        StartMove();
    }

    public void StartMove()
    {
        _moving = true;
    }

    void Update()
    {
        if (_moving)
        {
            if (_speed<MainGameController.Instance.SelectedTransmision.speed)
            {
                _speed += MainGameController.Instance.SelectedTransmision.acceleration;
                if (_speed> MainGameController.Instance.SelectedTransmision.speed)
                {
                    _speed = MainGameController.Instance.SelectedTransmision.speed;
                }
            }

            if (_speed > MainGameController.Instance.SelectedTransmision.speed)
            {
                _speed -= MainGameController.Instance.SelectedTransmision.braking;
                if (_speed < MainGameController.Instance.SelectedTransmision.speed)
                {
                    _speed = MainGameController.Instance.SelectedTransmision.braking;
                }
            }

            gameObject.transform.Translate(Vector3.down * (_speed * Time.deltaTime));
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
