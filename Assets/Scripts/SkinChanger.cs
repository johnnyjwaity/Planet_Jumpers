using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour {

    public Sprite[] allSkins;
    public string[] spriteId;
    
    public GameObject glowSphere;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Equip"))
        {
            PlayerPrefs.SetString("Equip", "default");
        }

        string currentEquip = PlayerPrefs.GetString("Equip");
        int index = 0;
        foreach(string currentId in spriteId)
        {
            if(currentId == currentEquip)
            {
                GetComponent<SpriteRenderer>().sprite = allSkins[index];
            }
            index++;
        }

        //GetComponent<SpriteRenderer>().sprite = allSkins[3];
        if(currentEquip == "default")
        {
            glowSphere.SetActive(true);
        }
        else
        {
            glowSphere.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
