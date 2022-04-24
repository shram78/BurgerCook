using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z);
    }
}
