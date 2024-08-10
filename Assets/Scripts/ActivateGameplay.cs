using UnityEngine;

public class ActivateGameplay : MonoBehaviour
{
    [SerializeField] float timeToWait = 5f;

    PlayerControls _playerControls;
    CollisionHandler _collisionHandler;
    float _initialTime;
    
    void Start()
    {
        _playerControls = GetComponent<PlayerControls>();
        _collisionHandler = GetComponent<CollisionHandler>();

        _initialTime = Time.time + timeToWait;
        DeactivateLasers();
    }

    private void DeactivateLasers()
    {
        foreach (GameObject laser in _playerControls.lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
    }

    void Update()
    {
        EnableGameplay(Time.time > _initialTime);
    }

    void EnableGameplay(bool isActive)
    {
        _playerControls.enabled = isActive;
        _collisionHandler.enabled = isActive;
        if (isActive) {enabled = false;}
    }
}
