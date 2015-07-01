using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {
	GameObject target;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 follow = target.transform.position;
		follow.z = transform.position.z;
		transform.position = follow;
	
	}
}
