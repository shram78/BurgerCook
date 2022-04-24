using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private TouchInput _touchInput;
    [SerializeField] private float _strafeSpeed;
    [SerializeField] private float _rangeStrafe;
    [SerializeField] private float _speedForward;

    private float _strafeValue;

    private void OnEnable()
    {
        _touchInput.Touched += OnTouched;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_strafeValue * _strafeSpeed * Time.fixedDeltaTime,
                                         transform.localPosition.y,
                                         transform.localPosition.z +_speedForward * Time.fixedDeltaTime);
    }

    private void OnDisable()
    {
        _touchInput.Touched -= OnTouched;
    }

    private void OnTouched(float mouseDeltaSwipe)
    {
        if ( CanMove(mouseDeltaSwipe))
            _strafeValue -= mouseDeltaSwipe;
    }



    private bool CanMove(float mouseDeltaSwipe)
    {
        if (mouseDeltaSwipe > 0 && transform.position.x > _rangeStrafe * (-1))
            return true;

        else if (mouseDeltaSwipe < 0 && transform.position.x < _rangeStrafe)
            return true;

        else
            return false;
    }
}
