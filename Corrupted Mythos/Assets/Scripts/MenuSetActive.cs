using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSetActive : MonoBehaviour
{
    [SerializeField]
    Button firstButton;

    private void OnEnable()
    {
        firstButton.Select();
    }
}
