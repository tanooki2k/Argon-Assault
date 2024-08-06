using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 10;

    ScoreBoard _scoreBoard;

    void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1) { KillEnemy(); }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        
        hitPoints--;
        _scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        _scoreBoard.IncreaseScore(scorePerHit * 2);
        
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}