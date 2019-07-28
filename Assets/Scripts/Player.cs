using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float VerticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //print(HorizontalThrow);
        float xOffset = Time.deltaTime * HorizontalThrow * xSpeed;
        float yOffset = Time.deltaTime * VerticalThrow * xSpeed;
        //print(xOffset);
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawNewXPos, -xRange, xRange), 
            Mathf.Clamp(rawNewYPos,-4,4), 
            transform.localPosition.z);
    }
}
