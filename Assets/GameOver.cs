using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text box;
	private string[] mlp = {"Madlord Punt","Nadlord Pumt","Nadlod Prumt","Nodlad Prumt","Donald Prumt","Donald Trump",""};
	private int i = 0;
	private System.Random generator = new System.Random();

	public void unscramble()
	{
		if(mlp[i]!= "")
		{	
			box.text = mlp[i];
			i+=1;
		}
	
		else
		{
			box.text = generator.Next(1, 65536).ToString();
		}
	}




}
