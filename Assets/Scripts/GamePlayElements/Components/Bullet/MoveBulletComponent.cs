using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/**
 * Bullet moving to point 
 * */
public class MoveBulletComponent : BulletGamePlayComponent
{
    private bool _moving = false;

    protected override void InitStaticData()
    {
        StartMove();
    }

    private void StartMove()
    {
        _moving = true;
        BulletGamePlayController.gameObject.transform.rotation = AimAngle;
        StartCoroutine(BulletLive());
    }

    public override void Shutdown()
    {
        base.Shutdown();
        StopCoroutine(BulletLive());
        _moving = false;
    }
    
    /// <summary>
    /// Time of bullet live 
    /// </summary>
    /// <returns></returns>
    private IEnumerator BulletLive()
    {
        yield return new WaitForSeconds(WeaponData.bulletRage);
        PrefabCreatorManager.Instance.DestroyPrefab(BulletGamePlayController.gameObject);
    }

    /// <summary>
    /// Bullet moving 
    /// </summary>
    private void Update()
    {
        
        if (_moving && BulletGamePlayController!=null)
        {
             BulletGamePlayController.gameObject.transform.position = BulletGamePlayController.gameObject.transform.position + AimAngle * Vector3.up * WeaponData.bulletSpeed;
        }
    }
}
