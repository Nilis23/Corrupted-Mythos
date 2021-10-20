using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCounter : MonoBehaviour
{
    [SerializeField]
    Text counter;
    [SerializeField]
    PlayerHealth playerHP;
    [SerializeField]
    Image potionIco;

    int lastUpdate;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePotions();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastUpdate != playerHP.hpGainItems)
        {
            UpdatePotions();
        }
    }

    public void UpdatePotions()
    {
        counter.text = playerHP.hpGainItems.ToString();
        if (playerHP.hpGainItems == 0)
        {
            Color icoColor = potionIco.color;
            icoColor.a = 0.25f;
            potionIco.color = icoColor;
        }
        else
        {
            Color icoColor = potionIco.color;
            icoColor.a = 1f;
            potionIco.color = icoColor;
        }
        lastUpdate = playerHP.hpGainItems;
    }
}
