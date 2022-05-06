using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Guns _gun;

    public Transform _joinGunPoint; // get set 
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

    public int GetCount() // свойство сделать
    {
        return _foods.Count;
    }

    public Transform GetPreviousPosition()
    {
        return _foods[_foods.Count - 1].transform;
    }
}
