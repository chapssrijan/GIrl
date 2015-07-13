using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundtexture;


	public float placey1;
	public float placey2;

	public float placex1;
	public float placex2;


	public void OnGUI(){
		//diplays background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundtexture);
		 // displays buttons

		if (GUI.Button (new Rect (Screen.width * placex1 , Screen.height * placey1 , Screen.width * .2f, Screen.height * .1f), "Play Game")) {
			Application.LoadLevel(1);
		
		}
		if (GUI.Button (new Rect (Screen.width * placex2, Screen.height * placey2, Screen.width * .2f, Screen.height * .1f), "Exit")) {
			Application.Quit();
		
		}

	}
}
