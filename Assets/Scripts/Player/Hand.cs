using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Guns _gun;
    public Transform _joinGunPoint; // get set

    private List<Eat> _eat = new List<Eat>();
    private BoxCollider _collector;

    private void Start()
    {
        _collector = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _gun.DonatedFood += OnLostFood;
    }

    private void OnLostFood(Eat eat)
    {
        Vector3 newSizeCollector = new Vector3(_collector.size.x, _collector.size.y, _collector.size.z - 2f);
        _collector.size = newSizeCollector;

        _eat.Remove(eat);

        eat.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _gun.DonatedFood -= OnLostFood;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newSizeCollector = new Vector3(_collector.size.x, _collector.size.y, _collector.size.z + 2f);

        if (other.gameObject.TryGetComponent(out Eat eat))
        {
            AddEat(eat);

            eat.Init(this, _eat.Count);

            _collector.size = newSizeCollector;
        }
    }

    private void AddEat(Eat eat)
    {
        _eat.Add(eat);
    }
}
