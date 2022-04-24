using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isMakeSwipe;
    private const string _mouseAxisX = "Mouse X";

    public event UnityAction<float> Touched;

    private void Update()
    {
        if (_isMakeSwipe)
            Touched?.Invoke(Input.GetAxis(_mouseAxisX) * (-1));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isMakeSwipe = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isMakeSwipe = false;
    }
}