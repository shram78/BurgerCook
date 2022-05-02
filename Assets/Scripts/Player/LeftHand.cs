using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    [SerializeField] private Guns _gunsLeft;

    private List<Eat> _burgers = new List<Eat>();
    private BoxCollider _collector;

    private void Start()
    {
        _collector = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _gunsLeft.DonatedFood += OnLostFood;
    }

    private void OnLostFood(Eat burger)
    {
        Vector3 newSizeCollector = new Vector3(_collector.size.x, _collector.size.y, _collector.size.z - 2f);
        _collector.size = newSizeCollector;


        _burgers.Remove(burger);

        burger.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _gunsLeft.DonatedFood -= OnLostFood;

    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newSizeCollector = new Vector3(_collector.size.x, _collector.size.y, _collector.size.z + 2f);

        if (other.gameObject.TryGetComponent(out Eat burger))
        {
            AddBurger(burger);

            burger.Init(this, _burgers.Count);

            _collector.size = newSizeCollector;
        }
    }

    private void AddBurger(Eat burger)
    {
        _burgers.Add(burger);
    }

    //public Burger CalculatePreviousBurger()
    //{
    //    for (int i = 0; i < _burgers.Count - 1; i++)
    //    {
    //        _previousBurger = _burgers[_burgers.Count - 1];

    //        Debug.Log(_previousBurger);
    //    }

    //    return _previousBurger;
    //}

}
