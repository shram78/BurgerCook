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
    [SerializeField] private GameObject _prefabShoot;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _miniFood;
    [SerializeField] private ParticleSystem _jumpParticle;
    [SerializeField] private ParticleSystem _takeParticle;
    [SerializeField] private ParticleSystem _takeFlare;

    private List<Food> _eat = new List<Food>();

    public event UnityAction<Food> FoodLoaded;
    public event UnityAction TookGun;

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
        if (other.gameObject.TryGetComponent(out Food eat))
        {
            FoodLoaded?.Invoke(eat);

            _eat.Add(eat);

            MakeJump();
        }

        else if (other.gameObject.TryGetComponent(out Player player))
            TakeInHand();
    }

    private void MakeJump()
    {
        _jumpParticle.Play();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_gun.transform.DOLocalMoveY(0.5f, 0.05f)).SetRelative();
        sequence.Append(_gun.transform.DOLocalMoveY(-0.5f, 0f)).SetRelative();
    }

    private void OnShooting()
    {
        StartCoroutine(EatingDelay());

        _miniFood.transform.DOLocalMoveZ(0.3f, 0.7f).SetLoops(_eat.Count, LoopType.Restart).SetRelative();
    }

    private IEnumerator EatingDelay()
    {
        var waitForSecond = new WaitForSeconds(0.5f);

        for (int i = 0; i < _eat.Count; i++)
        {
            var eatPrefab = Instantiate(_prefabShoot, _shootPoint);
            eatPrefab.transform.DOMove(_boss._mouthPoint.position, 1f);
            eatPrefab.transform.SetParent(null);

            _hand.MakeRecoil();

            yield return waitForSecond;
        }
    }

    private void TakeInHand()
    {
        StartCoroutine(HideONTimer());
        gameObject.transform.SetParent(_hand._joinPoint.transform);
        transform.DOMove(_hand._joinPoint.position, 0f);
    }

    private IEnumerator HideONTimer()
    {
        _gun.gameObject.SetActive(false);

        float timeLeft = 0.3f;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        _gun.gameObject.SetActive(true);
        _miniFood.gameObject.SetActive(true);
        _takeParticle.Play();
        _takeFlare.Play();

        TookGun?.Invoke();
    }
}
