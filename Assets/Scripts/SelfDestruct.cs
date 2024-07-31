using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 1f;
    
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}