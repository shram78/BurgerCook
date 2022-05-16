using UnityEngine;

public class FoodShoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _smokeParticle;
    [SerializeField] private ParticleSystem _confettiParticle;

    private void Start()
    {
        _confettiParticle.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Mouth mouth))
        {
            _smokeParticle.Play();

            Destroy(gameObject, 0.3f);
        }
    }
}
