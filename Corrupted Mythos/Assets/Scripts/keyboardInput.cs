using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CorruptedMythos
{
    public class keyboardInput : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKey(KeyCode.D))
            {
                inputManager.Instance.MoveRight = true;
            }
            else
            {
                inputManager.Instance.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputManager.Instance.MoveLeft = true;
            }
            else
            {
                inputManager.Instance.MoveLeft = false;
            }

        }
    }
}