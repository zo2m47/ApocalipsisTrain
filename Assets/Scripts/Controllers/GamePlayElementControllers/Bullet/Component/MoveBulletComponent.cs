using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/**
 * Bullet moving to point 
 * */
public class MoveBulletComponent : BaseBulletComponent
{
    private bool _moving = false;

    protected override void InitActionListener()
    {
        base.InitActionListener();
        StartMove();
    }

    private void StartMove()
    {
        Debug.Log(AimAngle);
        _bulletController.gameObject.transform.rotation = AimAngle;
        _moving = true;
    }

    private void Update()
    {
        if (_moving)
        {
            _bulletController.gameObject.transform.position = _bulletController.gameObject.transform.position + AimAngle * Vector3.up * 0.2f;
        }
    }

    protected override void RemoveActionListener()
    {
        base.RemoveActionListener();
    }
}
