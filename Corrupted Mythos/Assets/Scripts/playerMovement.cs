using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CorruptedMythos
{
    public class playerMovement : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(inputManager.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            }
            if (inputManager.Instance.MoveLeft)
            {
                this.gameObject.transform.Translate(-Vector3.forward * 10f * Time.deltaTime);
            }
        }
    }
}

