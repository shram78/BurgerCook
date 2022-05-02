using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Guns : MonoBehaviour
{
    [SerializeField] private LeftHand _leftHand;
    [SerializeField] private Boss _boss;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _prefab;

    private List<Eat> _burgers = new List<Eat>();
    private MeshRenderer _meshRenderer;

    public event UnityAction<Eat> DonatedFood;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _boss.OpenedMounth += OnShooting;
    }

    private void OnDisable()
    {
        _boss.OpenedMounth -= OnShooting;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Eat burger))
        {
            DonatedFood?.Invoke(burger);
            AddBurger(burger);
        }

        else if (other.gameObject.TryGetComponent(out Player player))
        {
            TakeInHand();
        }
    }

    private void OnShooting()
    {
        StartCoroutine(EatingDelay());
    }

    private IEnumerator EatingDelay()
    {
        var waitForSecond = new WaitForSeconds(0.5f);

        for (int i = 0; i < _burgers.Count; i++)
        {
            var eatPrefab = Instantiate(_prefab, _shootPoint);

            eatPrefab.transform.DOMove(_boss._mouthPoint.position, 1f);

            yield return waitForSecond;
        }
    }

    private void AddBurger(Eat burger)
    {
        _burgers.Add(burger);
    }

    private void TakeInHand()
    {
        StartCoroutine(HideONTimer());
        gameObject.transform.SetParent(_leftHand.transform);
    }

    private IEnumerator HideONTimer()
    {
        _meshRenderer.enabled = false;
        float timeLeft = 0.3f;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        _meshRenderer.enabled = true;
    }
}
