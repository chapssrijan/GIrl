using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	Rigidbody2D rb;
	public float speed=5;
	public float jumpspeed;
	bool up=false;
	bool down=false;
	bool right=false;
	bool left=false;
	bool jump = false;
	Animator animation1;
	
	// Use this for initialization
	void Start () {
		scalex =  transform.localScale.x;
		animation1 = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Ground")
			jump = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			up = true;
			
		} else
			up = false;
		
		
		if (Input.GetKey (KeyCode.S)) {
			down = true;
			
		} else
			down = false;
		
		if (Input.GetKey (KeyCode.D)) {
			right = true;
			
		} else
			right = false;
		
		if (Input.GetKey (KeyCode.A)) {
			left = true;
			
		} else
			left = false;
	}
	float scalex;
	void FixedUpdate()
	{
		
		if (up && jump) {
			rb.AddForce (transform.up * jumpspeed);
			up = false;
			jump = false;
		}
		if(down)
			rb.AddForce (-transform.up *speed);
		if (right) {
			rb.AddForce (transform.right * -speed);
			if(transform.localScale.x < 0)
				transform.localScale= new Vector3(scalex,transform.localScale.y,transform.localScale.z);
			
		}
		if (left) {
			rb.AddForce (-transform.right * -speed);
			if(transform.localScale.x > 0)
				transform.localScale= new Vector3(-scalex,transform.localScale.y,transform.localScale.z);
			
		}
	
		
		
		
	}

}
