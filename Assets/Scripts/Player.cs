using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;
    [Tooltip("In m")] [SerializeField] float yRange = 6f;

    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float throwPitchFactor = 3f;
    [SerializeField] float positionYawFactor = -3f;
    [SerializeField] float throwRollFactor = -4f;

    float HorizontalThrow, VerticalThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Player collided with something");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered something");
    }

    // Update is called once per frame
    void Update()
    {
        PositionControl();
        RotationControl();
    }

    private void PositionControl()
    {
        HorizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        VerticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //print(HorizontalThrow);
        float xOffset = Time.deltaTime * HorizontalThrow * xSpeed;
        float yOffset = Time.deltaTime * VerticalThrow * xSpeed;
        //print(xOffset);
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawNewXPos, -xRange, xRange),
            Mathf.Clamp(rawNewYPos, -yRange, yRange),
            transform.localPosition.z);
    }

    private void RotationControl()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + VerticalThrow*throwPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = HorizontalThrow*throwRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
    }
}
