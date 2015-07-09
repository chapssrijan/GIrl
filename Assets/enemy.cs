using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	


	Vector3 spawnpoints;
	Transform _transform;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform> ();
		spawnpoints = _transform.position ;
	



	}
	public void die(){
		Debug.Log (name + "Died");
		_transform.position =spawnpoints;


	}


		

}