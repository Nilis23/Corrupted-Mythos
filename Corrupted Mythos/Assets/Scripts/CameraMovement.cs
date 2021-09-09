using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Inputs Theplayer;
    private Vector2 DD;

    private void OnEnable()
    {
        Theplayer = new Inputs();
        Theplayer.Enable();
    }
    private void OnDisable()
    {
        Theplayer.Disable();
    }
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        DD.x = Theplayer.player.movement.ReadValue<Vector2>().x;
        //transform.position += DD(DD.x * Time.deltaTime, 0, 0);
    }
}
