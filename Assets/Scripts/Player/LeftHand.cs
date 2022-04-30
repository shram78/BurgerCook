using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    private List<Burger> _burgers = new List<Burger>();
    private Burger _previousBurger;
    private BoxCollider _collector;


    private void Start()
    {
        _collector = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newSizeCollector = new Vector3(_collector.size.x, _collector.size.y, _collector.size.z + 2f);

        if (other.gameObject.TryGetComponent(out Burger burger))
        {
            AddBurger(burger);

            burger.Init(this, _burgers.Count);

            _collector.size = newSizeCollector;
        }
    }

    private void AddBurger(Burger burger)
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
