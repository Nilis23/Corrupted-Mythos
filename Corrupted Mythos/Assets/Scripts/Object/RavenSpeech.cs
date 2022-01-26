using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenSpeech : MonoBehaviour
{
    [SerializeField]
    List<string> dialouge;

    bool talk = false;
    bool change = false;
    int indx = 0;
    GameObject textholder;
    private Inputs pcontroller;

    // Start is called before the first frame update
    void Start()
    {
        pcontroller = FindObjectOfType<PlayerMovement>().pcontroller;
        if (dialouge != null && dialouge.Count > 0 && dialouge[0] != "")
        {
            talk = true;
            for (int i = 0; i < dialouge.Count; i++)
            {
                dialouge[i] = dialouge[i].Replace("\\n", "\n");
            }

            textholder = transform.GetChild(0).gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (talk && collision.gameObject.tag == "Player")
        {
            textholder.SetActive(true);
            StartCoroutine(ProgressSpeech());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (talk && collision.gameObject.tag == "Player" && pcontroller.player.attack.ReadValue<float>() > 0 && textholder.activeSelf && !change)
        {
            indx++;
            if(indx == dialouge.Count)
            {
                //Close the text box
                textholder.SetActive(false);
                change = false;
                indx = 0;
            }
            else
            {
                change = true;
                StartCoroutine(ProgressSpeech());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (talk && collision.gameObject.tag == "Player")
        {
            textholder.SetActive(false);
            indx = 0;
        }
    }

    IEnumerator ProgressSpeech()
    {
        int i = 0;
        while(i < dialouge[indx].Length)
        {
            string text = dialouge[indx].Substring(0, i);
            textholder.transform.GetChild(0).GetComponent<TextMesh>().text = text;
            i++;

            yield return new WaitForSeconds(0.2f);
        }
        change = false;
    }
}
