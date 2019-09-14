using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingScript : MonoBehaviour {
	public 	List<StatClass> items;
	public float cauldronCD;
	//playerinventory
	string[] PlayerInv = {"Water", "Oil", "Wine", "Herb", "Mushroom"};
	int[] invcount = {0,0,0,0,0} ;
	StatClass PlayerPTN;
	
	//POTION IMAGE
	public GameObject POTIONprefab;
	public Sprite HP;
	public Sprite ATK;
	public Sprite CURE;

	
	
	// Use this for initialization
	void Start () {
        items = new List<StatClass>();

        items.Add(new StatClass("Water", 0, 0, "BASE", 0, 2));
        items.Add(new StatClass("Oil", 0, 1, "BASE", 0, 0));
        items.Add(new StatClass("Wine", 0, 2, "BASE", 0, 7));
        items.Add(new StatClass("Herb", 2, 0, "HP", 10, 5));
        items.Add(new StatClass("Venom", 0, 0, "PSN", 15, 7));
        items.Add(new StatClass("Mushroom", 0, 1, "ATK", 15, 0));
		items.Add(new StatClass("WTRhrb", 2, 0, "POTION", 10, 0));
		items.Add(new StatClass("OILhrb", 2, 0, "POTION", 10, 0));
		items.Add(new StatClass("WINhrb", 4, 0, "POTION", 10, 0));
		items.Add(new StatClass("WTRpow", 0, 2, "POTION", 15, 0));
		items.Add(new StatClass("OILpow", 0, 2, "POTION", 15, 0));
		items.Add(new StatClass("WINpow", 0, 3, "POTION", 15, 0));
		items.Add(new StatClass("WTRVen", 0, 0, "PSN", 15, 0));
		items.Add(new StatClass("WINVen", 0, 0, "PSNRES", 15, 0));
		items.Add(new StatClass("OILVen", 0, 0, "PSN", 15, 0));
	}
	
	void Update () {
			//player inventory
		for(int x = 0; x < 5; x++)
		{
			Debug.Log(PlayerInv[x]);
			Debug.Log(invcount[x]);
		}
	}
	//which potion is it
	StatClass getitembyID(string Name)
	{
		foreach (StatClass item in items)
		{
			
			if(item.NAME == name)
			{
				return item;
			}
		}
		return null;
	}
	
	//asign potion
    public void Craft(string BASE, string frsting,string scnding)
    {
		StatClass potion;
      if(BASE == "Water")
		{
		  if(frsting == "Herb")
		  {
			  potion = getitembyID("WTRhrb");
		  }
		  else if(frsting == "Mushroom")
		  {
			  potion = getitembyID("WTRpow");
		  }
		  else if(frsting == "Venom" && scnding != "")
		  {
			  potion = getitembyID("WTRVen");
		  }
		  
		}
		else if(BASE == "Wine")
		{
		  if(frsting == "Herb")
		  {
			  potion = getitembyID("WINhrb");
		  }
		  else if(frsting == "Mushroom")
		  {
			  potion = getitembyID("WINpow");
		  }
		  else if(scnding == "Venom")
		  {
			  potion = getitembyID("WINVen");
		  }
		  
		}
		else if(BASE == "Oil")
		{	
			int oilRDM;
			oilRDM = Random.Range(0,2);
		  if(frsting == "Herb")
		  {
			  potion = getitembyID("OILhrb");
			  if(oilRDM == 0)
			  {
				  potion.HP = 0;
			  }
			  else if(oilRDM == 1)
			  {
				  potion.HP = 2;
			  }
			  else if(oilRDM == 2)
			  {
				  potion.HP = 4;
			  }
		POTIONprefab.GetComponent<SpriteRenderer>().sprite = HP;
		  }
		  else if(frsting == "Mushroom")
		  {
			  potion = getitembyID("OILpow");
			  if(oilRDM == 0)
			  {
				  potion.PWR = 1;
			  }
			  else if(oilRDM == 1)
			  {
				  potion.PWR = 2;
			  }
			  else if(oilRDM == 2)
			  {
				  potion.PWR = 4;
			  }
		POTIONprefab.GetComponent<SpriteRenderer>().sprite = ATK;
		  }
		  else if(scnding == "Venom")
		  {
			  potion = getitembyID("OILVen");
			  if(oilRDM == 0)
			  {
				  potion.STATUS = "NA";
			  }
			  else if(oilRDM == 1)
			  {
				  potion.STATUS = "PSN";
			  }
			  else if(oilRDM == 2)
			  {
				  potion.STATUS = "PSNRES";
			  }
		cauldronCD = potion.SPD;
		cauldronCD -= Time.deltaTime;
		POTIONprefab.GetComponent<SpriteRenderer>().sprite = CURE;
		PlayerPTN = potion;
		
		}

		POTIONprefab = Instantiate(POTIONprefab);

		}

	}	

		/*give potion to hero
		public void giveHero(StatClass Potion)
		{
			HeroPTN = Potion;
		}*/
		

}