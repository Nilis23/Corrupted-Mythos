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
        SelectButton();
    }

    public void SelectButton()
    {
        StartCoroutine("doButtonSelect");
    }

    IEnumerator doButtonSelect()
    {
        yield return new WaitForEndOfFrame();
        firstButton.Select();

    }
}
