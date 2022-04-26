using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerHoneyBrick : MonoBehaviour
{
    [SerializeField] private List<PlaceHoneyBrick> _honeyBrickPlaces;

    private int _currentHoneyBricksCollected;

    public IReadOnlyList<PlaceHoneyBrick> Places => _honeyBrickPlaces;

    private int _needHoneyBricksToBuy => _honeyBrickPlaces.Count;

    public event UnityAction<int, int> BrickAmountChanged;
    public event UnityAction BrickPlaced;

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _honeyBrickPlaces.Add(transform.GetChild(i).GetComponent<PlaceHoneyBrick>());
        }
    }

    private void Start()
    {
        BrickAmountChanged?.Invoke(_needHoneyBricksToBuy, _currentHoneyBricksCollected);
    }

    public void AddBrick()
    {
        _currentHoneyBricksCollected++;
        BrickPlaced?.Invoke();

        BrickAmountChanged?.Invoke(_needHoneyBricksToBuy, _currentHoneyBricksCollected);
    }
}
