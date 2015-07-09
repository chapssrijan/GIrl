using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
	public int lifes = 3;


	BoxCollider2D b;

	GameObject lifesc;
	GameObject players;
	Vector3 spawnpoint;
	// Use this for initialization
	void Start () {
		lifesc = GameObject.Find ("Canvas/lifes");
		b = GetComponent<BoxCollider2D >();
		spawnpoint = transform.position;
		scalex =  transform.localScale.x;
		animation1 = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	
		players = GameObject.Find ("player");
	}
	public void die(){
		if (lifes > 0) {
			lifes--;
			transform.position = spawnpoint;

			GameObject[] tmp = GameObject.FindGameObjectsWithTag ("enemy");
			foreach (GameObject i in tmp) {
				i.SendMessageUpwards ("die", SendMessageOptions.DontRequireReceiver);
			}
		} else
			Application.LoadLevel (0);
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Ground"){
			jump = true;
		}
		if (other.collider.tag == "enemy") {
			die ();
		}
		if(other.collider.tag=="Goblin"){
			die ();
			}
		if (other.collider.tag == "newplayer") {
		
			Destroy (players);
		}


	 

			         }

	bool movee = false;
	// Update is called once per frame
	void Update () {

		lifesc.GetComponent<Text> ().text = "Lifes: " + lifes;
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
		
		}
	
		Debug.Log ("Velocity: " + rb.velocity.x);

		//caps the velocity to wanted value
		if(Mathf.Abs (rb.velocity.x)< 5f ){
		if (right) {
			rb.AddForce (transform.right * speed);

			if(transform.localScale.x < 0)
				transform.localScale= new Vector3(scalex,transform.localScale.y,transform.localScale.z);
			
		}
		 if (left) {
			rb.AddForce (transform.right * -speed);
		
			if(transform.localScale.x > 0)
				transform.localScale= new Vector3(-scalex,transform.localScale.y,transform.localScale.z);
			
		}
		
		 if(down){



				b.size= new Vector2(0.87f,0.7f);

				if(transform.localScale.x <0)
					transform.localScale= new Vector3(-scalex,transform.localScale.y,transform.localScale.z);

			}
			else
				b.size= new Vector2(0.87f,0.95f);

		}
	
		if (!movee) {
			rb.velocity = new Vector2(0,rb.velocity.y);
		}
		if ((left || right) && !down && !up) {
			animation1.SetBool ("moving", true);
			animation1.Play ("Boy_Move");
		} else if (up) {
			animation1.Play ("Boy_Jump");
		
		} else if (down) {
			animation1.Play ("Boy_Crouch");
		}
		else {
			animation1.SetBool ("moving",false);
			animation1.Play("Boy_Idle");
		}
		
		
	}

	


}
