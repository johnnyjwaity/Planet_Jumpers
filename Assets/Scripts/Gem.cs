using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    private float pointsToGive;
    private PointTracker pt;
	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Gems"))
        {
            PlayerPrefs.SetInt("Gems", 0);
        }
        //pt = FindObjectOfType<PointTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            //pt.addPoints(1);
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems")+1);
            Destroy(gameObject);
        }
        
    }

}
