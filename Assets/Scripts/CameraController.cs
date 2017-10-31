using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = player.transform.position;
        newPosition.z = -10;
        transform.position = Vector3.Lerp(transform.position, newPosition, speed);
	}
}
