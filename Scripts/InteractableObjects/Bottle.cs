using UnityEngine;

public class Bottle : MonoBehaviour,IInteractable
{
    [SerializeField] private ParticleSystem _particle;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Interact()
    {
        Instantiate(_particle, _transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
