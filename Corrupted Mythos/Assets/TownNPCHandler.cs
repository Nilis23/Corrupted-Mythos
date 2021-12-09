using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownNPCHandler : MonoBehaviour
{
    enum NPC
    {
        NPC1,
        NPC2,
        NPC3,
        NPC_Blacksmith,
        NPC_Merchant
    }

    [SerializeField]
    NPC type;
    [SerializeField]
    string dialouge;

    bool talk = false;
    GameObject textholder;

    private void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger(type.ToString());
        if (dialouge != null && dialouge != "")
        {
            talk = true;
            textholder = transform.GetChild(0).gameObject;
            textholder.transform.GetChild(0).GetComponent<TextMesh>().text = dialouge;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (talk && collision.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.name);
            textholder.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (talk && collision.gameObject.tag == "Player")
        {
            textholder.SetActive(false);
        }
    }
}
