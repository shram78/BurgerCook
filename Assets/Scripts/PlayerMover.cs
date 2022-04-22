using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private float _speedForfard;
    [SerializeField] private float _speedStrafe;
    [SerializeField] private float _rangeStrafe;

    private void Update()
    {
        transform.Translate(_speedForfard * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.A) && transform.position.x >= -_rangeStrafe)
            StrafeLeft();

        if (Input.GetKey(KeyCode.D) && transform.position.x <= _rangeStrafe)
            StrafeRight();
    }

    private void StrafeLeft()
    {
        transform.Translate(_speedStrafe * Time.deltaTime * Vector3.left);
    }

    private void StrafeRight()
    {
        transform.Translate(_speedStrafe * Time.deltaTime * Vector3.right);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
                Debug.Log("RRRR");
        else
            Debug.Log("LLL");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
