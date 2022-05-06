using UnityEngine;

public class Pepsi : Food
{
    [SerializeField] private GameObject _water;
    [SerializeField] private GameObject _cap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GatePepsi gatePepsi))
        {
            _water.gameObject.SetActive(true);
        }

        else if (other.gameObject.TryGetComponent(out GateCapPepsi gatePepsiCap))
        {
            _cap.gameObject.SetActive(true);
        }
    }
}
