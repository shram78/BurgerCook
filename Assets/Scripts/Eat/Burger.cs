using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : Eat
{
    [SerializeField] private GameObject _bulkaTop;
    [SerializeField] private GameObject _salat;
    [SerializeField] private GameObject _tomato;
    [SerializeField] private GameObject _cheese;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GateTomato gateTomato))
        {
            _tomato.gameObject.SetActive(true);
        }

        else if (other.gameObject.TryGetComponent(out GateSalat gateSalat))
        {
            _salat.gameObject.SetActive(true);
        }

        else if (other.gameObject.TryGetComponent(out GateTop gateTop))
        {
            _bulkaTop.gameObject.SetActive(true);
        }
    }

}
