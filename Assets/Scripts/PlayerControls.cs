using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")] [SerializeField] float controlSpeed = 18f;
    [Tooltip("How far player moves horizontally")] [SerializeField] float xRange = 16.5f;
    [Tooltip("How far player moves vertically")] [SerializeField] float yRange = 11f;


    [Header("Laser gun array")]
    [Tooltip(("Add all players laser here"))] [SerializeField] public GameObject[] lasers;

    
    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -.1f;
    [SerializeField] float positionYawFactor = 1.46f;
    
    
    [Header("Player input based tuning")]
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float controlRollFactor = -25f;

    float _xThrow, _yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = _yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = _xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    void ProcessTranslation()
    {
        _xThrow = Input.GetAxis("Horizontal");
        _yThrow = Input.GetAxis("Vertical");

        float xOffset = (controlSpeed * _xThrow) * Time.deltaTime;
        float yOffset = (controlSpeed * _yThrow) * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}