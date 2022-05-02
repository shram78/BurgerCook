using UnityEngine;

public class Eat : MonoBehaviour
{
    private float _radius = 1f;
    private int _maxEatInChain = 10;
    public bool _isKeep = false;
    private int _eatCount;
    private LeftHand _hand;

    public void Init(LeftHand hand, int eatCount)
    {
        _eatCount = eatCount;
        _isKeep = true;
        _hand = hand;
    }

    private void Update()
    {
        float positionZ = _radius * _eatCount;
        float deltaValve = (_maxEatInChain - _eatCount);

        if (_isKeep)
        {

            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _hand.transform.position.x, deltaValve * Time.deltaTime),
                                                               transform.position.y,
                                                               _hand.transform.position.z + positionZ);
        }
    }
}
