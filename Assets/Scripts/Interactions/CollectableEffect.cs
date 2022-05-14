using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableEffect : MonoBehaviour
{
    [SerializeField] private PointUI _pointUI;

    private int _point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
        {
            ChangeScale(food);

            _point++;
            _pointUI.OnShow(_point);
        }
    }

    private void ChangeScale(Food food)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(food.transform.DOScale(1.2f, 0.1f));
        sequence.Insert(1f, food.transform.DOScale(1f, 0.1f));
    }
}
