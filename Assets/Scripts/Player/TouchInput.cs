using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const string MouseAxisX = "Mouse X";
    private bool _isMakeSwipe;

    public event UnityAction<float> Touched;

    private void Update()
    {
        if (_isMakeSwipe)
            Touched?.Invoke(Input.GetAxis(MouseAxisX) * (-1));
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