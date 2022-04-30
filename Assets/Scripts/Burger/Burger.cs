using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Burger : MonoBehaviour
{
    private float _radiusBurger = 1f;
    private int _maxBurgerInChain = 10;
    public bool _isKeep = false;
    private int _burgerCount;
    private LeftHand _leftHand;
    private BoxCollider _boxCollider;


    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent(out Burger burger))
    //    {
    //        // Debug.Log("Burger + burger");
    //        _leftHand.AddBurger(burger);
    //           //_isKeep = true;
    //        //        OnJoined();
    //    }
    //}

    public void Init(LeftHand leftHand, int burgerCount)
    {
        _burgerCount = burgerCount;
        _isKeep = true;
        _leftHand = leftHand;
        _boxCollider.enabled = false;
    }

    private void Update()
    {
        float positionZ = _radiusBurger * _burgerCount;
        float deltaValve = (_maxBurgerInChain - _burgerCount);

        if (_isKeep)
        {

            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _leftHand.transform.position.x, deltaValve * Time.deltaTime),
                                                               transform.position.y,
                                                               _leftHand.transform.position.z + positionZ);
        }
    }


}
