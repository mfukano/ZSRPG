﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	public Texture backgroundTexture;
	public float buttonWidth = 0.5f;
	public float buttonHeight = 0.12f;
	public float pos = 0.25f;
	public GUIStyle style;
	Player myPlayer;


	void Start() {
		myPlayer = (Player)GameObject.FindObjectOfType (typeof(Player));
		style.normal.textColor = Color.white;
		style.alignment = TextAnchor.UpperCenter;
		style.fontSize = 30;
	}

	void OnGUI(){
		//display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		//display menu buttons
		if (GUI.Button (new Rect (Screen.width*pos, (float)Screen.height*1.75F*pos, Screen.width*buttonWidth, (float)Screen.height*0.75F*buttonHeight), "New Game")){
			DontDestroyOnLoad(myPlayer);
			Application.LoadLevel("Aridae_Final");
		}
		if (GUI.Button (new Rect (Screen.width * pos, (float)Screen.height*2.5F* pos, Screen.width * buttonWidth, (float)Screen.height*0.75F*buttonHeight), "Test Suite")) {
			Application.LoadLevel ("TestMenu");
		}
		if (GUI.Button (new Rect (Screen.width*pos, (float)Screen.height*3.25F*pos, Screen.width*buttonWidth, (float)Screen.height*0.75F*buttonHeight), "Quit")) {
			Application.Quit();
		}
	}
}
