using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public GameObject startPlanet;
    private Transform target;
    public float speed;
    private float desiredCamSize;
    private float duration = 0.5f;
    public float yOffset;
	// Use this for initialization
	void Start () {
        //player = FindObjectOfType<PlayerController>().gameObject;
        target = startPlanet.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            target = player.transform;
            desiredCamSize = 21;
        }
        else
        {
            target = startPlanet.transform;
            
            desiredCamSize = 33;
        }

        if(Mathf.Abs(desiredCamSize-GetComponent<Camera>().orthographicSize) > 0.5) 
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(desiredCamSize, GetComponent<Camera>().orthographicSize, duration/Time.deltaTime);
        }
        

        Vector3 newPosition = target.position;
        newPosition.z = -10;
        if(player == null)
        {
            newPosition.y += yOffset;
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, speed);
	}
}
