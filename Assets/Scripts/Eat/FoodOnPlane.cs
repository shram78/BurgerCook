using UnityEngine;

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
    }
}
