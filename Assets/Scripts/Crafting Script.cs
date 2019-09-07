using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<StatClass> items = new List<StatClass>();

        items.Add(new StatClass("Water", 0, 0, "BASE", 0, 0));
        items.Add(new StatClass("Oil", 0, 1, "BASE", 0, 0));
        items.Add(new StatClass("Wine", 0, 2, "BASE", 0, 0));
        items.Add(new StatClass("Herb", 2, 0, "HP", 10, 0));
        items.Add(new StatClass("Venom", 0, 0, "PSN", 15, 0));
        items.Add(new StatClass("Powder", 0, 2, "ATK", 15, 0));
		items.Add(new StatClass("WTRhrb", 2, 0, "POTION", 0, 0));
		items.Add(new StatClass("OILhrb", 2, 0, "POTION", 0, 0));
		items.Add(new StatClass("WINhrb", 4, 0, "POTION", 0, 0));
		items.Add(new StatClass("WTRpow", 0, 2, "POTION", 0, 0));
		items.Add(new StatClass("OILpow", 0, 2, "POTION", 0, 0));
		items.Add(new StatClass("WINpow", 0, 4, "POTION", 0, 0));
		items.Add(new StatClass("AntiVen", 0, 0, "PSN", 0, 0));
		items.Add(new StatClass("OILVen", 0, 0, "PSN", 0, 0));
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void Craft(string BASE, string frsting,string scnding)
    {
		string potion;
      if(BASE == "Water")
		{
		  if(frsting == "Herb")
		  {
			  potion = "WTRhrb";
		  }
		  else if(frsting == "Powder")
		  {
			  potion = "WTRpow";
		  }
		  else if(frsting == "Venom" && scnding != "")
		  {
			  potion = "AntiVen";
		  }
		  
		}
		else if(BASE == "Wine")
		{
		  if(frsting == "Herb")
		  {
			  potion = "WINhrb";
		  }
		  else if(frsting == "Powder")
		  {
			  potion = "WINpow";
		  }
		  else if(scnding == "Venom")
		  {
			  potion = "AntiVen";
		  }
		  
		}
		else if(BASE == "Oil")
		{
		  if(frsting == "Herb")
		  {
			  potion = "OILhrb";
		  }
		  else if(frsting == "Powder")
		  {
			  potion = "OILpow";
		  }
		  else if(scnding == "Venom")
		  {
			  potion = "OILVen";
		  }
		  
		  // Give(potion); <--give to potion to player
		}
	}	


}