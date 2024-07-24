// using System.Collections;
// using System.Collections.Generic;

using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 18f;
    [SerializeField] float xRange = 16.5f;
    [SerializeField] float yRange = 11f;

    [SerializeField] float positionPitchFactor = -.1f;
    [SerializeField] private float controlPitchFactor = -20f;
    
    [SerializeField] float positionYawFactor = .98f;
    
    [SerializeField] private float controlRollFactor = -25f;

    float _xThrow, _yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = _yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = _xThrow * controlRollFactor;
        
        float pitch =  pitchDueToPosition + pitchDueToControlThrow;
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
}