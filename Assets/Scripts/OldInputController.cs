using System;
using UnityEngine;

public class OldInputController : MonoBehaviour
{
    [SerializeField] float ControlSpeed = 2f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7.5f;

    [SerializeField] float xRotFactor = 2;
    [SerializeField] float yRotFactor = 2;

    [SerializeField] float xInputfactor;
    [SerializeField] float yInputfactor;


    [SerializeField] GameObject[] lasers;

    float xInput, yInput;


    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        bool fireInput = Input.GetButton("Fire1");
        StartShooting(fireInput);
    }

    private void StartShooting(bool fireInput)
    {
        foreach (GameObject laser in lasers)
        {
            var val = laser.GetComponent<ParticleSystem>().emission;
            val.enabled = fireInput;
        }
    }

    private void ProcessTranslation()
    {
        xInput = Input.GetAxis("Horizontal");
        float xOffset = xInput * Time.deltaTime * ControlSpeed;
        float xPosRaw = transform.localPosition.x + xOffset;
        float xPosClamped = Mathf.Clamp(xPosRaw, -xRange, xRange);

        yInput = Input.GetAxis("Vertical");
        float yOffset = yInput * Time.deltaTime * ControlSpeed;
        float yPosRaw = transform.localPosition.y + yOffset;
        float yPosClamped = Mathf.Clamp(yPosRaw, -yRange, yRange); //This can work like this as we are taking initional position to be 0,0

        transform.localPosition = new Vector3(xPosClamped, yPosClamped, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float xRotDueToPosition = transform.localPosition.y * xRotFactor;
        float xRotDueToInput = yInput * yInputfactor;
        float xRot = xRotDueToPosition + xRotDueToInput;

        float yRotDueToPosition = transform.localPosition.x * yRotFactor;
        float yRot = yRotDueToPosition;

        float zRotDueToInput = xInput * xInputfactor;
        float zRot = zRotDueToInput;

        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    
}
