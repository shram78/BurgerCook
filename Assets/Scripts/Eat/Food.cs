using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _radius = 1.5f;

    public bool _isKeep = false;
    private float _foodCount;
    private Hand _hand;
    private Transform _previousFoodPosition;
    private float _currentLenghtChain;
    private float movingValve = 10f;

    private void FixedUpdate()
    {
        if (_isKeep)
            StartMoving();
    }

    public void Init(Hand hand)
    {
        _isKeep = true;
        _hand = hand;

        _foodCount = _hand.GetCount(); // 

        transform.SetParent(null);

        _previousFoodPosition = _hand.GetPreviousPosition();

        _currentLenghtChain = _radius * _foodCount;
    }

    private void StartMoving()
    {
        Vector3 headPosition = new Vector3(_hand.transform.position.x, _hand.transform.position.y, _hand.transform.position.z + _radius);
        Vector3 tailPosition = new Vector3(_previousFoodPosition.position.x, transform.position.y, headPosition.z + _currentLenghtChain);

        transform.position = Vector3.Lerp(transform.position, tailPosition, movingValve * Time.fixedDeltaTime);
    }
}
