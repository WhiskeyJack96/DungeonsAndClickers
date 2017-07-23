using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleView : MonoBehaviour {

	public GameObject view;


	public void toggle()
	{
		view.SetActive(!view.activeSelf); 
	}
}
