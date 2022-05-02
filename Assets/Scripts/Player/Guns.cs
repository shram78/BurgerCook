using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Guns : MonoBehaviour
{
    [SerializeField] private Hand _hand;
    [SerializeField] private Boss _boss;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private MeshRenderer _meshRenderer;
    private List<Eat> _eat = new List<Eat>();

    public event UnityAction<Eat> DonatedFood;

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
        if (other.gameObject.TryGetComponent(out Eat eat))
        {
            DonatedFood?.Invoke(eat);
            AddEat(eat);
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

        for (int i = 0; i < _eat.Count; i++)
        {
            var eatPrefab = Instantiate(_prefab, _shootPoint);

            eatPrefab.transform.DOMove(_boss._mouthPoint.position, 1f);

            yield return waitForSecond;
        }
    }

    private void AddEat(Eat eat)
    {
        _eat.Add(eat);
    }

    private void TakeInHand()
    {
        StartCoroutine(HideONTimer());
        gameObject.transform.SetParent(_hand.transform);
        transform.DOMove(_hand._joinGunPoint.position, 0f);
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
