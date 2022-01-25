using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public Vector2 parallaxEffect;
    private float textureSize;

    private void OnEnable()
    {
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureSize = texture.width / sprite.pixelsPerUnit;
        parallaxEffect = new Vector2(cameraTransform.position.z + transform.position.z, 0);
    }

    private void lateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect.x, deltaMovement.y * parallaxEffect.y, 0);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureSize)
        {
            float offsetPosition = (cameraTransform.position.x - transform.position.x) % textureSize;
            transform.position = new Vector3(cameraTransform.position.x+offsetPosition, transform.position.y);
        }
    }
}
