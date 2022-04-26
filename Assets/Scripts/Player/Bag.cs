using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Bag : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _brickContainer;
    [SerializeField] private BoxCollider _brickCollector;

    private int _brickCount = 0;

    public int BrickCount => _brickCount;

    public ContainerHoneyBrick BrickContainer => _brickContainer;

    private bool _isFull => _brickCount >= _brickContainer.Places.Count;

    public event UnityAction<int> BrickCollected;
    public event UnityAction<int> BrickSell;

    public void Put()
    {
        _brickCount++;

        BrickCollected?.Invoke(_brickCount);

        if (_isFull)
            _brickCollector.enabled = false;
    }


    public HoneyBrick SellBrick()
    {
        HoneyBrick honeyBrick = null;

        if (_brickCount > 0)
        {
            _brickCount--;

            honeyBrick = transform.GetChild(_brickCount).GetComponent<HoneyBrick>();

            BrickSell?.Invoke(_brickCount);

            if (_brickCollector.enabled == false && _isFull == false)
                _brickCollector.enabled = true;
        }

        return honeyBrick;
    }
}
