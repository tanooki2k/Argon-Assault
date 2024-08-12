using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;

    ScoreBoard _scoreBoard;
    GameObject _parentGameObject;
    
    void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        _parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1) { KillEnemy(); }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = _parentGameObject.transform;
        
        hitPoints--;
        _scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        _scoreBoard.IncreaseScore(2 * scorePerHit);

        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = _parentGameObject.transform;
        Destroy(gameObject);
    }
}