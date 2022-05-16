using UnityEngine;
using DG.Tweening;

public class FoodOnPlane : MonoBehaviour
{
    [SerializeField] private Food _foodFrefab;
    [SerializeField] private Hand _hand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
            SpawnFood();
    }

    private void SpawnFood()
    {
        gameObject.SetActive(false);

        Food _newFood = Instantiate(_foodFrefab, transform.position, Quaternion.identity);
        _newFood.Init(_hand);
        _hand.AddFood(_newFood);

        ChangeScale(_newFood);
    }

    private void ChangeScale(Food food)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(food.transform.DOScale(1.2f, 0.1f));
        sequence.Insert(0.5f, food.transform.DOScale(1f, 0.1f));
    }
}
