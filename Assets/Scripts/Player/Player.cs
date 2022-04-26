using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bag _bag;

    public Bag Bag => _bag;
}
