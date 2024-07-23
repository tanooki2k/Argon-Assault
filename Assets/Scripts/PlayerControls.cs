// using System.Collections;
// using System.Collections.Generic;

using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 18f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 5.1f;

    [SerializeField] float positionPitchFactor = -3.6f;
    [SerializeField] private float controlPitchFactor = -10f;

    float _xThrow, _yThrow;
    private float _diff = 2.45f;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = (transform.localPosition.y - _diff) * positionPitchFactor;
        float pitchDueToControlThrow = _yThrow * controlPitchFactor;
        
        float pitch =  pitchDueToPosition + pitchDueToControlThrow;
        float yaw = 0f;
        float roll = 0f;
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
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange + _diff, yRange + _diff);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}