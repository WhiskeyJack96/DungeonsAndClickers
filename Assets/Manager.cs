using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public Text hp;
	public Text ar;
	public Text wp;
	public Text tr;
	public Text rr;

	public Text xp;
	public Text fm;
	public Level lvl;
	public Text mh;

	public GameObject ouch;
	public GameObject eat;

	public Counter fcounter;
	public Counter gcounter;

	public Button invbutton;
	public Button camp;

	public bool cooldown = true; 
	public float invCooldown;

	private int[] xpbreakpoints = {300,900,2700,6500,14000,23000,34000,48000,64000,85000,100000};


	private bool hurt = true;

	private string[] weapons = {"Fists","Glaive", "Defender's Glaive", "Dragon Slayer's Glaive", "Holy Avenger", "Azreal's Providence"};
	private string[] armors = {"Urchin Clothes","Chain Mail", "Mithral Armor", "Adamantite Armor", "Dragon Scale Mail", "Demon's Armor"};
	private string[] trinkets = {"Dragon's Talon Necklace","Dungeoneer's Pack","Ioun Stone", "Amulet of Health", "Periapt of Wound Closure", "Storm Giant's Belt","Animated Shield", "Deck of Many Things"};
	//private string[] trinkets = {"DTN","D's Pack","IS", "AH", "PWC", "SGB","AS", "DMT"};
	//private string[] weapons = {"Fists","G", "D's G", "DSG", "HA", "AP"};
	//private string[] armors = {"Urchin Clothes","CM", "MA", "AA", "DSM", "DA"};
		
	public StoryController story;

	//private string[] armortext = {"Buy yourself some armor boy, lest you get stabbed to death on the road.","Your chain mail is torn, buy yourself something new, maybe mithral would be a good choice", "Good lord you've managed to tear your mithral, try getting some adamantite",
//									"I think you should use those silver scales to make yourself some new armor, something a lord deserves", "Here take this armor, it was worn by a king I devoured in a previous age", };
//	private string[] weapontext = {"Judging by your strength I recommend you pick up a Glaive, it will allow you to keep you foes at a distance while you destroy them","Maybe you should seek out an enchanter to get your glaive upgraded to a defender's glaive",
//									"Take some of those copper scales and get the dragonslayer enchantment put on your glaive boy","My lord that hill giant had a holy avenger, pick that up and get it fixed at the local blacksmith","Here take Azreal's Providence a glaive wielded by the angel of Harmony"};
//	private string[] trinkettext = {"Ahh yes thank you lad, if you can manage to return this talon to me I will reward you greatly", "Ahh a Dungeoneer's pack these contain all sorts of goodies to help a lad like you on a quest", "I sense an amulet of wealth in the store over there, buy it",
//									"A Periapt of Wound Closure is nearby see if you can find it and purchase it", "That Storm Giant had a belt on, you could have it identified it might be useful", "That belt increases your strength you can now wield your glaive in one hand, you might want to consider finding a shield",
//									"Here take my Deck of Many Things it has the ability to grant you great power"};



	private int healfactor = 1;


	public bool inv = false;

	private int savingthrows{get;set;}
	private int level{get;set;}
	private int fame{get;set;}
	private float maxHealth{get;set;}

	private float health{get;set;}
	public int weapon{get;set;}
	private int armor{get;set;}
	private int trinket{get;set;}
	private int hitmax{get;set;}
	private int hitdie{get;set;}


	private string rank{get;set;}

	private System.Random generator;
	void Awake()
	{
		level = 1;
		fame = 1;
		maxHealth = health = 16;
		rank = "John Punt";
		weapon = 0;
		armor = 0;
		trinket = 0;
		hitmax = hitdie = 2;

		savingthrows = 0;

		updateStats();
		generator = new System.Random();
	}

	public void levelUp()
	{
		int currentXP;
		int.TryParse(xp.text.Split(' ')[0], out currentXP);
		if(currentXP >= xpbreakpoints[level-1])
		{
			fcounter.count += xpbreakpoints[level-1]/5;
			fcounter.updateText();
			level++;
			lvl.updateLevel(level.ToString());
			int up = generator.Next(1,8);
			health = maxHealth = maxHealth+up;
			hitmax++;
			hitdie=hitmax;
		}
		updateStats();
	}

	public void updateFame(string newrank)
	{
		rank = newrank + " Punt";
		updateStats();
	}


	public void heal(int amount)
	{
		health += amount * healfactor;
		if(health >maxHealth)
		{
			health = maxHealth;
		}
		updateStats();
	}

	public void damage(string type)
	{
		if(inv)
		{
			return;
		}
		char del = ' ';
		string[] thing = type.Split(del);
		int dice,num;
		int.TryParse(thing[0], out dice);
		int.TryParse(thing[1], out num);
		float dmg = 0;
		for(int i =0; i<num; i++){dmg+= generator.Next(1,dice+1);}
		health -= dmg/(armor+1);

		if(health<=0f)
		{
			Injured();
			health = generator.Next(1,8);
			savingthrows++;
		}
		updateStats();
	}

	public void Injured()
	{
		fcounter.updateCount(-fcounter.count/2);
		gcounter.updateCount(-gcounter.count/2);
		StartCoroutine(OUCH());
		if(hurt)
		{hurt = false; story.updatestory("Looks like you lost that fight, you lost half your fame and gold. Stop failing and bring me my talon!");}
	}

	IEnumerator OUCH()
	{
		ouch.SetActive(true);
		yield return new WaitForSeconds(8);
		ouch.SetActive(false);
	}

	public void gameover()
	{
		fcounter.updateCount(-fcounter.count/2);
		gcounter.updateCount(-gcounter.count/2);
		Debug.Log("GameOver");
	}

	public void parsePurchase(string purchase)
	{
		string[] fields = purchase.Split(' ');
		switch(int.Parse(fields[0]))
		{
			case 0:
				updateWeapon(int.Parse(fields[1]));
				break;
			case 1:
				updateArmor(int.Parse(fields[1]));
				break;
			case 2:
				updateTrinket(int.Parse(fields[1]));
				break;
			case 5:
				restoreHitDie();
				break;

		}
	}

	public int GetCost(string purchase)
	{
		if(purchase == "5 0")
		{
			return (int)(gcounter.count * .1f);
		}
		if(purchase == "6 0")
		{
			return (int)(gcounter.count *.25f);
		}
		return 0;
	}

	public  void updateWeapon(int w)
	{
		weapon= w;
		updateStats();
	}

	public  void updateArmor(int a)
	{
		armor= a;
		updateStats();
	}

	public void restoreHitDie()
	{
		hitdie=hitmax;
	}

	public void useHitDie(int num)
	{
		if(maxHealth == health)
		{
			return;
		}
		if(hitdie >0)
		{
			hitdie--;
			int roll = generator.Next(1,8);
			heal(roll);
		}

		if(hitdie ==0)
		{
			eat.SetActive(false);
			camp.interactable = true;
		}
	}

	public void trinketHealing(int amount)
	{
		maxHealth +=amount;
		health+= amount;
	}
	
	public void trinketwoundClosure(int amount)
	{
		savingthrows-=amount;
		healfactor = 2;

	}
	//giant belt
	
	//random effect for random duration

	public void trinketAnimShield(float time)
	{
		if(cooldown)
		{
			StartCoroutine(WaitforINV(time));
			StartCoroutine(Cooldown(invCooldown));
		}
	}

	IEnumerator Cooldown(float time)
	{	
		cooldown = false;
		yield return new WaitForSeconds(time);
		cooldown = true;


	}

	IEnumerator WaitforINV(float time)
    {
    	inv = true;
    	invbutton.enabled = false;
        yield return new WaitForSeconds(time);
        inv = false;
        invbutton.enabled = true;
    }


	public void updateTrinket(int t)
	{
		switch(t)
		{
			case(1):
			story.display("The store will have more inventory as you complete more quests, I will let you know when you should think about finding new things");
				break;
			case(2):
			//dunno
				break;
			case(3):
			//nocrit
				break;
			case(4):
				trinketHealing(25);
				break;
			case(5):
				trinketwoundClosure(2);
				break;
			case(6):
				break;
			case(7):
				break;
		}
		trinket= t;
		tr.text += trinkets[trinket-1] + "\n";
		updateStats();
	}

	void updateStats()
	{
		hp.text = "Health: " + health.ToString("0.00");
		mh.text = "Max Health: " + maxHealth.ToString();
		ar.text = armors[armor];
		wp.text = weapons[weapon];
		rr.text = rank;
	}
}
