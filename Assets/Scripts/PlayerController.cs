using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject planet;
    public GameObject point;
    public GameObject oppPoint;
    Rigidbody2D myRb;
    public float speed;
    public float gravityPull;
    public GameObject directionPoint;
    public GameObject jumpPoint;
    public float jumpForce;

    public bool onLand;
    public float rotationSpeed;


    public float landGravity;
    public float maxSpeed;

    // Use this for initialization
    void Start () {
        myRb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(planet != null)
        {
            myRb.gravityScale = 0f;
            var directionToPlanet = transform.position - planet.transform.position;
            directionToPlanet.Normalize();

            var gravity = directionToPlanet * -gravityPull;
            if (onLand)
            {
                gravity = directionToPlanet * -landGravity;

            }
            
            myRb.AddForce(gravity);
            Vector2 line1 = planet.transform.position - point.transform.position;
            Vector2 line2 = planet.transform.position - transform.position;


            //transform.LookAt(planet.transform);
            float angle = Vector2.Angle(line1, line2);
            if (transform.position.x > planet.transform.position.x)
            {
                angle *= -1;
            }
            Quaternion newRotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.z + angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed);
        }
        else
        {
            myRb.gravityScale = 1.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.zero), rotationSpeed);
        }

        Debug.Log(myRb.velocity.magnitude);
        if(myRb.velocity.magnitude > maxSpeed && onLand)
        {
            myRb.velocity = myRb.velocity.normalized * maxSpeed;
        }
        


        if(Input.GetKey("d")){
            //if(planet.transform.position.y <= transform.position.y){
            //    myRb.AddForce(Vector2.right * speed);
            //}
            //else{
            //    myRb.AddForce(Vector2.left * speed);
            //}
            if(onLand){
                Vector2 direction = transform.position - directionPoint.transform.position;
                myRb.AddForce(direction.normalized * -speed);  
            }


            //With Help and Inspiration From Jakuub


        }
        if (Input.GetKey("a"))
        {
            //if(planet.transform.position.y <= transform.position.y){
            //    myRb.AddForce(Vector2.right * speed);
            //}
            //else{
            //    myRb.AddForce(Vector2.left * speed);
            //}
            if (onLand)
            {
                Vector2 direction = transform.position - oppPoint.transform.position;
                myRb.AddForce(direction.normalized * -speed);
            }


            //With Help and Inspiration From Jakuub


        }
        if (Input.GetKey(KeyCode.Space)){
            if(onLand){
                gravityPull = 15;
                Vector2 direction = transform.position - jumpPoint.transform.position;
                myRb.AddForce(direction.normalized * -jumpForce);   
            }

        }


	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Planet"){
            onLand = true;
            gravityPull = 50;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            onLand = false;

        }
    }

}
