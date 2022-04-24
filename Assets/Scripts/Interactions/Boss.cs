using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Boss : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finishTrigger;

    private void OnEnable()
    {
        _finishTrigger.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _finishTrigger.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(15, 1f).SetRelative()); 
        sequence.Append(transform.DOLocalRotate(Vector3.zero, 0.5f));
        sequence.Insert(1f, transform.DOPunchPosition(new Vector3(5, 10, 5), 1f));
    }
}
