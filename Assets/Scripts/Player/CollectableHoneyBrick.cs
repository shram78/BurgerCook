using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.Events;
public class CollectableHoneyBrick : MonoBehaviour
{
    public event UnityAction Taken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bag bag))
        {
            CollectToBag(bag);

            bag.Put();

            Taken?.Invoke();
        }
    }

    private void CollectToBag(Bag bag)
    {
        float FlyingEffectValue = 0.5f;
        float FlightTime = 0.05f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveZ(FlyingEffectValue * (-1), FlightTime).SetRelative());
        sequence.Append(transform.DOLocalMoveZ(FlyingEffectValue, FlightTime).SetRelative());

        transform.SetParent(bag.transform);
        transform.position = bag.BrickContainer.Places[bag.BrickCount].transform.position;
    }
}
