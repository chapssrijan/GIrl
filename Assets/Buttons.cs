using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public float placey1;
	public float placey2;
	
	public float placex1;
	public float placex2;


	public void OnGUI(){
		if (GUI.Button (new Rect (Screen.width * placex1, Screen.height * placey1, Screen.width * .2f, Screen.height * .1f), "Play Game")) {
			Application.LoadLevel (1);
		
		}
		if (GUI.Button (new Rect (Screen.width * placex2, Screen.height * placey2, Screen.width * .2f, Screen.height * .1f), "Exit")) {
			Application.Quit ();
		
		}
	}
}
