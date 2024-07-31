using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] private Transform parent;

    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}