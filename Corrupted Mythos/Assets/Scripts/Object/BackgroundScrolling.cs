using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float parallaxEffectMultiplier;


    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
