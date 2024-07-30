using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{name} I'm hit by {other.gameObject.name}");
        Destroy(gameObject);
    }
}
