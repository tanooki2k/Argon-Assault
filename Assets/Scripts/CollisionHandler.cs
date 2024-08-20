using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] AudioClip crashSFX;

    PlayerControls _playerControls;
    AudioSource _audioSource;

    private void Start()
    {
        _playerControls = GetComponent<PlayerControls>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        ShowCrashFX();
        DeactivateGameplay();
        Invoke("ReloadLevel", loadDelay);
    }

    void ShowCrashFX()
    {
        _audioSource.PlayOneShot(crashSFX);
        crashVFX.Play();
    }

    void DeactivateGameplay()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        DeactivateLasers();
        _playerControls.enabled = false;
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    private void DeactivateLasers()
    {
        foreach (GameObject laser in _playerControls.lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
    }
}