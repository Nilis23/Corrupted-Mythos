using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEMP_tracker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Enemies_to_kill;

    // Update is called once per frame
    void Update()
    {
        bool end = true;
        foreach(GameObject obj in Enemies_to_kill)
        {
            if(obj != null)
            {
                end = false;
            }
        }

        if (end)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
