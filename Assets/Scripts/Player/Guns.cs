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

    private List<Food> _eat = new List<Food>();

    public event UnityAction<Food> DonatedFood;

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
            DonatedFood?.Invoke(eat);

            _eat.Add(eat);

            MakeJump();
        }

        else if (other.gameObject.TryGetComponent(out Player player))
        {
            TakeInHand();
        }
    }

    private void MakeJump()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_gun.transform.DOLocalMoveY(0.5f, 0.05f)).SetRelative();
        sequence.Append(_gun.transform.DOLocalMoveY(-0.5f, 0f)).SetRelative();
    }

    private void OnShooting()
    {
        StartCoroutine(EatingDelay());

        _miniFood.transform.DOLocalMoveZ(0.3f, 0.7f).SetLoops(-1, LoopType.Restart).SetRelative();
    }

    private void MakeRecoil()
    {
        int forceRecoil = Random.Range(5, 35);
        float timeRecoil = Random.Range(0.05f, 0.3f);

        Vector3 endPosition = new Vector3(forceRecoil, 0f, 0f);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_gun.transform.DOLocalRotate(endPosition, timeRecoil).SetRelative());
        sequence.Append(_gun.transform.DOLocalRotate(-endPosition, timeRecoil).SetRelative());
    }

    private IEnumerator EatingDelay()
    {
        var waitForSecond = new WaitForSeconds(0.5f);

        for (int i = 0; i < _eat.Count; i++)
        {
            var eatPrefab = Instantiate(_prefabShoot, _shootPoint);
            _prefabShoot.transform.SetParent(null);
            eatPrefab.transform.DOMove(_boss._mouthPoint.position, 1f);

            MakeRecoil();

            yield return waitForSecond;
        }
    }

    private void TakeInHand()
    {
        StartCoroutine(HideONTimer());
        gameObject.transform.SetParent(_hand.transform);
        transform.DOMove(_hand._joinGunPoint.position, 0f);
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
    }
}
