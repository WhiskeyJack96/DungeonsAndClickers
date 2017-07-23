using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour {

	public Counter gold;
	public Button toDisable;
	public GameObject toEnable;
	public string storyprint = "";
	public string bought;
	public Manager player;
	public bool fame = false;
	public string newrank;
	public bool oneprint = false;

	public StoryController story;

	public void updateOne()
	{
		oneprint = true;
	}

	public void tryPurchase(int cost)
	{
		if(cost == 0)
		{
			cost = player.GetCost(bought);
		}
		if(gold.count >=cost)
		{
			gold.count -=cost;
			gold.updateText();
			if(story != null)
			{
				if(storyprint != "" && !oneprint)
					{
						story.updatestory(storyprint);
					}
			}
			if(fame)
			{
				player.updateFame(newrank);
			}
			if(toDisable != null)
			{
				toDisable.interactable = (false);
			}
			player.parsePurchase(bought);
			if(toEnable != null)
			{
				toEnable.SetActive(true);
			}
		}
	}

}
