using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


public class Hand : MonoBehaviour
{
    [SerializeField] private Guns _gun;

    public Transform _joinPoint; 
    private List<Food> _foods = new List<Food>();
    private Food _firstFood;

    private void Awake()
    {
        _firstFood = GetComponentInChildren<Food>();
        _foods.Add(_firstFood);
    }

    private void OnEnable()
    {
        _gun.DonatedFood += OnLostFood;
    }

    private void OnDisable()
    {
        _gun.DonatedFood -= OnLostFood;
    }

    private void OnLostFood(Food food)
    {
        _foods.Remove(food);

        food.gameObject.SetActive(false);
    }

    public void AddFood(Food eat)
    {
        _foods.Add(eat);
    }

    public int GetCount() 
    {
        return _foods.Count;
    }

    public Transform GetPreviousPosition()
    {
        return _foods[_foods.Count - 1].transform;
    }

    public void MakeRecoil()
    {
        int forceRecoil = UnityEngine.Random.Range(5, 35);
        float timeRecoil = UnityEngine.Random.Range(0.05f, 0.3f);
        Vector3 endPosition = new Vector3(forceRecoil, 0f, 0f);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalRotate(-endPosition, timeRecoil).SetRelative());
        sequence.Append(transform.DOLocalRotate(endPosition, timeRecoil).SetRelative());
    }
}
