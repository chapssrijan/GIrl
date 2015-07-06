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



	GameObject players;
	Vector3 spawnpoint;
	// Use this for initialization
	void Start () {

		spawnpoint = transform.position;
		scalex =  transform.localScale.x;
		animation1 = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	
		players = GameObject.Find ("player");
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Ground"){
			jump = true;
		}
		if (other.collider.tag == "enemy") {
			transform.position = spawnpoint;
		}
		if(other.collider.tag=="Goblin"){
				transform.position=spawnpoint;
			}
		if (other.collider.tag == "newplayer") {
		
			Destroy (players);
		}


	 

			         }

	bool movee = false;
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

		if (left || right) {
			movee = true;

		} else
			movee = false;

	}
	float scalex;
	void FixedUpdate()
	{
		
		if (up && jump) {
			rb.AddForce (transform.up * jumpspeed);
			up = false;
			jump = false;
			transform.localScale=new Vector2(scalex,0.4f);
		}
	
		Debug.Log ("Velocity: " + rb.velocity.x);

		//caps the velocity to wanted value
		if(Mathf.Abs (rb.velocity.x)< 5f ){
		if (right) {
			rb.AddForce (transform.right * speed);
				transform.localScale=new Vector2(scalex,0.4f);
			if(transform.localScale.x < 0)
				transform.localScale= new Vector3(scalex,transform.localScale.y,transform.localScale.z);
			
		}
		if (left) {
			rb.AddForce (transform.right * -speed);
				transform.localScale=new Vector2(scalex,0.4f);
			if(transform.localScale.x > 0)
				transform.localScale= new Vector3(-scalex,transform.localScale.y,transform.localScale.z);
			
		}
		
		if(down){

				rb.AddForce(transform.up *- speed);
				transform.localScale=new Vector2(scalex,0.4f);
				if(transform.localScale.x>0)
					transform.localScale=new Vector2(-scalex,0.4f);

			}
			else{
				
				transform.localScale=new Vector2(scalex,0.42f);

			}

		}
	
		if (!movee) {
			rb.velocity = new Vector2(0,rb.velocity.y);
		}
		if ((left || right) && !down) {
			animation1.SetBool ("moving", true);
			animation1.Play ("boy");
		} else if (up) {
			animation1.Play ("Jump");
		
		} else if (down) {
			animation1.Play ("crouch");
		}
		else {
			animation1.SetBool ("moving",false);
			animation1.Play("Idle");
		}
		
		
	}

	


}
