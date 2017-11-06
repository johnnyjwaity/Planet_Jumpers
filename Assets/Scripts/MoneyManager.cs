using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Gems"))
        {
            PlayerPrefs.SetInt("Gems", 0);
        }
        PlayerPrefs.SetInt("Gems", 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getBalance()
    {
        return PlayerPrefs.GetInt("Gems");
    }

    public void addMoney(int amount)
    {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") + amount);
    }

    public void subtractMoney(int amount)
    {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") - amount);
    }
}
