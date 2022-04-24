using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FinishTrigger : MonoBehaviour
{
    public event UnityAction Finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {

            Finished?.Invoke();
        }
    }
}
