using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

	public Text tex;

	public string[] swtich = new string[2];

	public void changeText()
	{
		if(tex.text == swtich[0])
		{
			tex.text = swtich[1];
		}
		else
		{
			tex.text = swtich[0];
		}
	}
}
