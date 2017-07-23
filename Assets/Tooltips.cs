using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltips : MonoBehaviour {

	public string message;
	public GUIStyle style;	
	public bool display;

	public void swpdisp()
	{
		display = !display;
	}

	void OnGUI()
	{
		//if(display)
		//{
		//	GUI.Label(new Rect(Screen.width / 2, Screen.height / 4, 200f, 200f), message,style);
		//}
	}
	// Update is called once per frame
	void Update () {
			
	}
}
