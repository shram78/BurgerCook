using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private FinishTrigger _finishTrigger;

    private bool _isFinish = false;

    private void Update()
    {
        if (!_isFinish)
            transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z);
    }

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
        _isFinish = true;
        float timeMoviing = 1f;
        float newCameraYPosition = 2f;
        float newCameraZPosition = 4f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalRotate(Vector3.zero, timeMoviing));
        sequence.Insert(0f, transform.DOLocalMoveY(newCameraYPosition, timeMoviing));
        sequence.Insert(0f, transform.DOLocalMoveZ(newCameraZPosition, timeMoviing).SetRelative());
    }
}
