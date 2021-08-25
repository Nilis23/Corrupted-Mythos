using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedMythos
{
    public class inputManager : MonoBehaviour
    {
        public static inputManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        public bool MoveRight;
        public bool MoveLeft;
    }
}

