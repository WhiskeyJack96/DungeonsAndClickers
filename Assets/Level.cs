using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public Text lvl;
	public void updateLevel(string l)
	{
		lvl.text = "Level: " + l;
	}

}
