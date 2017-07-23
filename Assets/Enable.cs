using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enable : MonoBehaviour {

	// Use this for initialization
	public Button button;
	public Counter counter;
	public int[] breakpoints;
	private int top = 0;

	private void checkUnlock()
	{
		if(counter.count >= breakpoints[top])
		{
			button.interactable = true;
		}
	}
	public void updatetop()
	{
		top++;
	}
	
	void Update()
	{
		checkUnlock();
	}

}
