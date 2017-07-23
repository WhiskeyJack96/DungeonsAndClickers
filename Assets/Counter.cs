using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
	public int start = 0;
	public string type;
	public int count;
	public Text parent;

	void Awake()
	{
		if(parent!=null)
		{
			type = parent.text;
		}
		count = start;
		updateText();
	}

	public void updateCount(int amount)
	{
			count+= amount;
			if(parent != null)
			{
			updateText();
			}
	}

	public void lowerCount(int cost)
	{
		if (cost>count)
		{
			return;
		}
		count-=cost;
	}

	public void spendPercent(int percent)
	{
		count -= count / percent;
		updateText();
	}

	public void updateText()
	{
		if(parent != null)
		{
		parent.text = count.ToString() + " " + type;
		}
	}
}
