using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceHoneyBrick : MonoBehaviour
{
    private HoneyBrick _honeyBrick;

    public bool IsAvailible { get; private set; }

    public event UnityAction<PlaceHoneyBrick> PlaceFree;

    private void Start()
    {
        IsAvailible = true;
    }

    public void Reserve(HoneyBrick honeyBrick)
    {
        IsAvailible = false;
        _honeyBrick = honeyBrick;
        _honeyBrick.GetComponent<CollectableHoneyBrick>().Taken += Free;
    }

    public void Free()
    {
        IsAvailible = true;
        PlaceFree?.Invoke(this);
        _honeyBrick.GetComponent<CollectableHoneyBrick>().Taken -= Free;
    }
}
