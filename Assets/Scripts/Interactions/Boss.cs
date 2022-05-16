using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finishTrigger;

    public Transform _mouthPoint;

    public event UnityAction OpenedMounth;

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
        StartCoroutine(SpawnTimer());

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(15, 1f).SetRelative());
        sequence.Append(transform.DOLocalRotate(Vector3.zero, 0.5f));
        sequence.Insert(1f, transform.DOPunchPosition(new Vector3(2, 5, 2), 1f));
    }

    private IEnumerator SpawnTimer()
    {
        float timeLeft = 2f;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        OpenedMounth?.Invoke();
    }
}
