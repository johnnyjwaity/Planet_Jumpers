using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

    public string idNum;
    public int cost;
    public bool defaultUnlocked;
    private bool unlocked;
    public Text buttonText;
    private MoneyManager mm;
    

	// Use this for initialization
	void Start () {
        mm = FindObjectOfType<MoneyManager>();
        if (!PlayerPrefs.HasKey(idNum))
        {
            if (defaultUnlocked)
            {
                PlayerPrefs.SetInt(idNum, 1);
            }
            else{
                PlayerPrefs.SetInt(idNum, 0);
            }
        }

        if (!PlayerPrefs.HasKey("Equip"))
        {
            PlayerPrefs.SetString("Equip", "default");
        }

	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt(idNum) == 1)
        {
            unlocked = true;
        }

        if (!unlocked)
        {
            buttonText.text = "Cost: " + cost;
        }
        else if(unlocked && PlayerPrefs.GetString("Equip") != idNum)
        {
            buttonText.text = "Equip";
        }
        else
        {
            buttonText.text = "Equipped";
        }
	}

    public void buttonHandler()
    {
        if (!unlocked)
        {
            if(mm.getBalance() >= cost)
            {
                mm.subtractMoney(cost);
                PlayerPrefs.SetInt(idNum, 1);
                
            }
        }
        else if(PlayerPrefs.GetString("Equip") != idNum)
        {
            PlayerPrefs.SetString("Equip", idNum);
        }
    }
}
