using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour {
    public GameObject point1;
    public GameObject point2;
    public float speed;
    private GameObject currentPoint;
    private int currentPointInt;
    public int waitTime;
    private float waitCounter;
    private bool waiting;
	// Use this for initialization
	void Start () {
        currentPoint = point1;
        currentPointInt = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (!waiting)
        {
            Vector3 direction = transform.position - currentPoint.transform.position;
            direction.Normalize();
            transform.position += direction * -speed * Time.deltaTime;

        }
        


        if(Vector3.Distance(currentPoint.transform.position, transform.position) < 3)
        {
            if(currentPointInt == 1)
            {
                if(waiting == false)
                {
                    waitCounter = waitTime;
                    waiting = true;
                }
                
                
            }
            else
            {
                currentPointInt = 1;
                currentPoint = point1;
            }
        }

        if (waiting)
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0)
            {
                currentPointInt = 2;
                currentPoint = point2;
                waiting = false;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(gameObject.transform);
        }
    }
}
