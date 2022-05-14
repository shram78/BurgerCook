using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LeftWrist : MonoBehaviour
{
    [SerializeField] private Guns _gun;

    private void OnEnable()
    {
        _gun.TakedGun += OnRotateGun;
    }

    private void OnDisable()
    {
        _gun.TakedGun -= OnRotateGun;

    }
    private void OnRotateGun()
    {
        transform.DOLocalRotate(new Vector3(90, 0, 0), 0.5f).SetRelative();
    }
}
