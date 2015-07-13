using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Spawn", 0, 1f);
	}
	void Spawn(){
		GameObject tmp = Instantiate (Resources.Load ("player"), transform.position, transform.rotation) as GameObject;
		GameObject.Find ("Main Camera").GetComponent<Kamera> ().target = tmp;

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
