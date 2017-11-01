using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public float gravity;
    public GameObject sphereOfInfluence;
    public GameObject PlanetBody;
    public GameObject Point;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.GetComponent<PlayerController>().planet = PlanetBody;
            collision.GetComponent<PlayerController>().gravityPull = gravity;
            collision.GetComponent<PlayerController>().point = Point;
        }
        Debug.Log("In Sphere");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player" && collision.GetComponent<PlayerController>().planet == PlanetBody)
        {
            collision.GetComponent<PlayerController>().planet = null;
            //collision.GetComponent<PlayerController>().gravityPull = gravity;
            collision.GetComponent<PlayerController>().point = null;
        }
        
    }

}
