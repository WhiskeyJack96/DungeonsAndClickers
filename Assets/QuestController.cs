using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour {

	public Text questtext;
	public Button parent;
	public GameObject[] toEnable = new GameObject[10];
	public int goal;
	public StoryController story;
	public int tier;

	public void checkquest()
	{
		if(questtext.GetComponent<Counter>().count < goal)
		{

		}
		else 
		{
			story.updatestore(tier);
			parent.interactable = false;

			foreach(GameObject to in toEnable)
			{
				to.SetActive(true);
			}

			//change parent color
		}
	}



}
