using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoryController : MonoBehaviour {

	public Text box;

	private string[] armortext = {"Buy yourself some armor boy, lest you get stabbed to death on the road.","Your chain mail is torn, buy yourself something new, maybe mithral would be a good choice", "Good lord you've managed to tear your mithral, try getting some adamantite",
									"I think you should use those silver scales to make yourself some new armor, something a lord deserves", "Here take this armor, it was worn by a king I devoured in a previous age", };
	private string[] weapontext = {"Judging by your strength I recommend you pick up a Glaive, it will allow you to keep you foes at a distance while you destroy them","Maybe you should seek out an enchanter to get your glaive upgraded to a defender's glaive",
									"Take some of those copper scales and get the dragonslayer enchantment put on your glaive boy","My lord that hill giant had a holy avenger, pick that up and get it fixed at the local blacksmith","Here take Azreal's Providence a glaive wielded by the angel of Harmony"};
	private string[] trinkettext = {"Ahh a Dungeoneer's pack will contain all sorts of goodies to help a lad like you on a quest", "I sense an amulet of health in the store over there, buy it",
									"A Periapt of Wound Closure is nearby see if you can find it and purchase it", "That Storm Giant had a belt on, you could have it identified it might be useful", "Here take my Deck of Many Things it has the ability to grant you great power"};




	public void display(string t)
	{
		box.text += t + "\n" + "\n";
	}

	public void updatestory(string story)
	{
		display(story);
	}

	public void updatestore(int tier)
	{
		display(armortext[tier]);
		display(weapontext[tier]);
		display(trinkettext[tier]);
	}
}
