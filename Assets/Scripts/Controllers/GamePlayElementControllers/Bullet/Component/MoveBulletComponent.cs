using System;
using System.Collections;
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
        _bulletController.gameObject.transform.rotation = AimAngle;
        _moving = true;
        StartCoroutine(BulletLive());
    }

    /// <summary>
    /// Time of bullet live 
    /// </summary>
    /// <returns></returns>
    private IEnumerator BulletLive()
    {
        yield return new WaitForSeconds(WeaponData.bulletRage);
        PrefabCreatorManager.Instance.DestroyPrefab(_bulletController.gameObject);
    }

    /// <summary>
    /// Bullet moving 
    /// </summary>
    private void Update()
    {
        if (_moving)
        {
            _bulletController.gameObject.transform.position = _bulletController.gameObject.transform.position + AimAngle * Vector3.up * WeaponData.bulletSpeed;
        }
    }

    protected override void RemoveActionListener()
    {
        base.RemoveActionListener();
        StopCoroutine(BulletLive());
        _moving = false;
    }
}
