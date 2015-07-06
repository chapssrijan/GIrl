using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	bool timer=false;
	float scalex;
	Vector3 spawnpoints;
	Rigidbody2D rb;
	public float speed=5;
	// Use this for initialization
	void Start () {
		spawnpoints = transform.position ;
		scalex =  transform.localScale.x;
		
		rb = GetComponent<Rigidbody2D> ();
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Player") {
			transform.position =spawnpoints  ;
		
		}
	}
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x >=-708.23) {
			
			timer = true;
		}
		
		if (transform.position.x <= -715) {
			
			timer = false;
		}
		
		
		if (timer) {
			rb.AddForce (transform.right * speed);
			{
				if (transform.localScale.x > 0)
					transform.localScale = new Vector3 (scalex, transform.localScale.y, transform.localScale.z);
			}
			
		} else {
			rb.AddForce (transform.right * -speed);
			if (transform.localScale.x < 0) {
				transform.localScale = new Vector3 (-scalex, transform.localScale.y, transform.localScale.z);
			}
		}
		
	}
}