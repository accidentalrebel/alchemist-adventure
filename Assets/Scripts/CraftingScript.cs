using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CraftingScript : MonoBehaviour {
	public List<StatClass> items;
	public float cauldronCD;
	//playerinventory need to be changed based on quest selection
	//InvManager ingredients = new InvManager();
	public Player player;
	public InvManager invmanager;

	string[] PlayerInv = {"Water", "Oil", "Wine", "Herb", "Mushroom", "Coffee", "Venom", "Salts", "Incense"}; 
	int[] invcount = new int[9];
	public Image[] InvIMG = new Image[9];
	StatClass PlayerPTN;
	bool haspotion = false;
	bool cancraft = true;
	
	//For Potion instance
	private GameObject _instance;
	public GameObject POTIONprefab;
	public Transform cauldron;
	public Sprite HP;
	public Sprite ATK;
	public Sprite PSN;
	public Sprite SPD;
	public Sprite STN;
	public Sprite CNF;
	
	//For selecting Ingredient
	public TMP_Text[] itemText = new TMP_Text[3];
	public Image[] itemImage = new Image[3];
	string[] Item = new string[3];
	public GameObject[] Box = new GameObject[3];
	//for shelf
	public TMP_Text[] itemcount;
	public GameObject Shelf;
	Transform[] Ingredients = Shelf.getChild();
	
	//for belt
	public StatClass[] Belt = new StatClass[3];
	public string whichBelt = "";
	public Sprite beltDefault;
	
	//private GameObject childObj;
	
	//gethero
	public Battle_npc[] Heroes = new Battle_npc[3];
	int Droprate = 30;

	
	// Use this for initialization
	void Start () {	
        items = new List<StatClass>();

        items.Add(new StatClass("Water", 0, 0, "BASE", 0, 2)); 
        items.Add(new StatClass("Oil", 0, 0, "BASE", 0, 5));
        items.Add(new StatClass("Wine", 0, 0, "BASE", 0, 7));
        items.Add(new StatClass("Herb", 1, 0, "FIRST", 0, 5));
        items.Add(new StatClass("Mushroom", 0, 1, "FIRST", 0, 8));
        items.Add(new StatClass("Coffee", 0, 0, "FIRST", 1, 4)); //new
		items.Add(new StatClass("Venom", 0, 0, "SECOND", 0, 4));
		items.Add(new StatClass("Salts", 0, 0, "SECOND", 0, 4)); //new
		items.Add(new StatClass("Incense", 0, 0, "SECOND", 0, 4)); //new
		items.Add(new StatClass("WTRhrb", 2, 0, "POTION", 3, 0));
		items.Add(new StatClass("OILhrb", 2, 0, "POTION", 4, 0));
		items.Add(new StatClass("WINhrb", 4, 0, "POTION", 5, 0));
		items.Add(new StatClass("WTRpow", 0, 2, "ATK", 3, 0));
		items.Add(new StatClass("OILpow", 0, 2, "ATK", 4, 0));
		items.Add(new StatClass("WINpow", 0, 3, "ATK", 5, 0));
		items.Add(new StatClass("WTRVen", 0, 0, "PSN", 3, 0));
		items.Add(new StatClass("WINVen", 0, 0, "PSN", 4, 0));
		items.Add(new StatClass("OILVen", 0, 0, "PSN", 5, 0));
		items.Add(new StatClass("WTRspd", 0, 2, "SPD", 1, 0)); //new
		items.Add(new StatClass("OILspd", 0, 2, "SPD", 1, 0)); //new
		items.Add(new StatClass("WINspd", 0, 3, "SPD", 1, 0)); //new
		items.Add(new StatClass("WTRStn", 0, 0, "STN", 3, 0)); //new
		items.Add(new StatClass("OILStn", 0, 0, "STN", 4, 0)); //new
		items.Add(new StatClass("WINStn", 0, 0, "STN", 5, 0)); //new
		items.Add(new StatClass("WTRCnf", 0, 0, "CNF", 3, 0)); //new
		items.Add(new StatClass("OILCnf", 0, 0, "CNF", 4, 0)); //new
		items.Add(new StatClass("WINCnf", 0, 0, "CNF", 5, 0)); //new
		
		
		//set invcount from prepphase
		for (int x = 0; x < 9; x++)
		{
			for (int y = 0; y< 9;y++)
			{
			if(Player.invmanager.items[y] == PlayerInv[x])
			{
				invcount[x]= Player.invmanager.count[y];
			}
			}
		}

			
	}
	
	void Update () {
		
		cauldronCD -= Time.deltaTime;
		for(int x = 0; x < invcount.Length; x++)
		{
			itemcount[x].text = invcount[x].ToString();
		}
		//Setting ingredient box images
		for(int x = 0; x < 3; x++)
			{
				if(Item[x] != null)
				{
					GameObject ForIngBox = GameObject.Find(Item[x]);
					Box[x].gameObject.SetActive(true);
					Box[x].GetComponent<Image>.sprite = ForIngBox.GetComponent<Image>().sprite;
				}
				else
				{
					Box[x].gameObject.SetActive(false);
				}
			}
			/*
		for(int x = 0; x < Ingredients.Length; x + 2)
			{
				
				if(Item[x] != null)
				{
					GameObject ForIngBox = GameObject.Find(Item[x]);
					Image[] images = ForIngBox.GetComponentsInChildren<Image>(true);
					Image theimage = images[1];
					theimage.gameObject.SetActive(true);
					
				}
				else
				{
					Box[x].gameObject.SetActive(false);
				}
			}
			*/
		foreach(var child in Ingredients)
		{
			for(int x = 0; x < 3; x++)
			{
				
				if (child.name == Item[x])
				{
					Image[] selection = child.GetComponentsInChildren<Image>(true);
					Image selected =  selection[1];
					selected.gameObject.SetActive(true);
				}
				else
				{
					Image[] selection = child.GetComponentsInChildren<Image>(true);
					Image selected =  selection[1];
					selected.gameObject.SetActive(false);
				}
			}
		}
	//which potion is it
	StatClass getitembyID(string Name)
	{
		foreach (StatClass item in items)
		{
			//Debug.Log(item.NAME + Name);
			if(item.NAME == Name)
			{
				//Debug.Log(item.NAME);
				return item;
			}
		}
		return null;
	}
	
	//Crafting Function
    public void Craft(string BASE, string frsting,string scnding)
    {
		StatClass potion = null;
      if(BASE == "Water")
		{
			invcount[0] -=1;
			if(scnding != null && frsting != null)
			{
				if(scnding == "Venom")
				{
					potion = getitembyID("WTRVen");
					POTIONprefab.GetComponent<Image>().sprite = PSN;
					invcount[6] -=1;				
				}
				else if(scnding == "Salts")
				{
					potion = getitembyID("WTRStn");
					POTIONprefab.GetComponent<Image>().sprite = STN;
					invcount[7] -=1;
				}
				else if(scnding == "Incense")
				{
					potion = getitembyID("WTRCnf");
					POTIONprefab.GetComponent<Image>().sprite = CNF;
					invcount[8] -=1;
				}
				for(int x = 0; x < invcount.Length;x++)
				{

					if(frsting == PlayerInv[x])
					{
						invcount[x] -=1;
					}
				}
			}
			else if(frsting == "Herb")
			{
				potion = getitembyID("WTRhrb");
				POTIONprefab.GetComponent<Image>().sprite = HP;
				invcount[3] -=1;
			}
			else if(frsting == "Mushroom")
			{
				potion = getitembyID("WTRpow");
				POTIONprefab.GetComponent<Image>().sprite = ATK;
				invcount[4] -=1;
			}
			//new items
			else if(frsting == "Coffee")
			{
				potion = getitembyID("WTRspd");
				POTIONprefab.GetComponent<Image>().sprite = SPD;
				invcount[5] -=1;
			}
		}
		else if(BASE == "Wine")
		{
			invcount[2] -=1;  
			if(scnding != null && frsting != null)
			{
				if(scnding == "Venom")
				{
					potion = getitembyID("WINVen");
					POTIONprefab.GetComponent<Image>().sprite = PSN;
					invcount[6] -=1;
					if(frsting == "Herb")
					{
						potion.HP = 1;
						invcount[3] -=1;					
					}
					else if(frsting == "Mushroom")
					{
						potion.PWR = 1;
						invcount[4] -=1;
					}
					else if(frsting == "Coffee")
					{
						potion.SPD = 1;
						invcount[5] -=1;
					}
				}
				if(scnding == "Salts")
				{
					potion = getitembyID("WINStn");
					POTIONprefab.GetComponent<Image>().sprite = STN;
					invcount[7] -=1;
						if(frsting == "Herb")
						{							
							potion.HP = 1;
							invcount[3] -=1;					
						}
						else if(frsting == "Mushroom")
						{
							potion.PWR = 1;
							invcount[4] -=1;
						}
						else if(frsting == "Coffee")
						{
							potion.SPD = 1;
							invcount[5] -=1;
						}
				}
				if(scnding == "Incense")
				{
					potion = getitembyID("WINCnf");
					POTIONprefab.GetComponent<Image>().sprite = CNF;
					invcount[8] -=1;
						if(frsting == "Herb")
						{
							potion.HP = 1;
							invcount[3] -=1;					
						}
						else if(frsting == "Mushroom")
						{
							potion.PWR = 1;
							invcount[4] -=1;
						}
						else if(frsting == "Coffee")
						{
							potion.SPD = 1;
							invcount[5] -=1;
						}
				}
			}
			else if(frsting == "Herb")
				{
					potion = getitembyID("WINhrb");
					POTIONprefab.GetComponent<Image>().sprite = HP;
					invcount[3] -=1;
				}
			else if(frsting == "Mushroom")
				{
					potion = getitembyID("WINpow");
					POTIONprefab.GetComponent<Image>().sprite = ATK;
					invcount[4] -=1;
				}
			else if(frsting == "Coffee")
				{
					potion = getitembyID("WINspd");
					POTIONprefab.GetComponent<Image>().sprite = SPD;
					invcount[5] -=1;
				}
		}
		else if(BASE == "Oil")
		{
			//oil need visual indicator to inform player if he got a bad or good result
			int oilRDM;
			invcount[1] -=1;
			oilRDM = Random.Range(1,3);
			if(scnding != null && frsting != null)
			{
				if(scnding == "Venom")
				{
					potion = getitembyID("OILVen");
					POTIONprefab.GetComponent<Image>().sprite = PSN;
					invcount[6] -=1;
					potion.STATUS = "PSN";
		
						if(frsting == "Herb")
							{
								potion.HP = oilRDM-1;
								invcount[3] -=1;
							}
						else if(frsting == "Mushroom")
							{
								potion.PWR = oilRDM-1;
								invcount[4] -= 1;
							}
						else if(frsting == "Coffee")
							{
								potion.SPD = oilRDM-1;
								invcount[4] -= 1;
							}
				}
				if(scnding == "Salts")
				{
					potion = getitembyID("OILStn");
					POTIONprefab.GetComponent<Image>().sprite = STN;
					invcount[7] -=1;
					potion.STATUS = "STN";
		
						if(frsting == "Herb")
							{
								potion.HP = oilRDM-1;
								invcount[3] -=1;
							}
						else if(frsting == "Mushroom")
							{
								potion.PWR = oilRDM-1;
								invcount[4] -= 1;
							}
						else if(frsting == "Coffee")
							{
								potion.SPD = oilRDM-1;
								invcount[4] -= 1;
							}
				}
				if(scnding == "Incense")
				{
					potion = getitembyID("OILCnf");
					POTIONprefab.GetComponent<Image>().sprite = CNF;
					invcount[8] -=1;
					potion.STATUS = "CNF";
		
						if(frsting == "Herb")
							{
								potion.HP = oilRDM-1;
								invcount[3] -=1;
							}
						else if(frsting == "Mushroom")
							{
								potion.PWR = oilRDM-1;
								invcount[4] -= 1;
							}
						else if(frsting == "Coffee")
							{
								potion.SPD = oilRDM-1;
								invcount[4] -= 1;
							}
				}
			}
			else if(frsting == "Herb")
			{
				potion = getitembyID("OILhrb");
				potion.HP = oilRDM;
				POTIONprefab.GetComponent<Image>().sprite = HP;
				invcount[3] -=1;
			}
			else if(frsting == "Mushroom")
			{
				potion = getitembyID("OILpow");
				potion.PWR = oilRDM;
				POTIONprefab.GetComponent<Image>().sprite = ATK;
				invcount[4] -=1;
			}
			else if(frsting == "Coffee")
			{
				potion = getitembyID("OILspd");
				potion.PWR = oilRDM;
				POTIONprefab.GetComponent<Image>().sprite = SPD;
				invcount[5] -=1;
			}
		}
		PlayerPTN = potion;		
		//cauldron cooldown
		cauldronCD = potion.SPD;
		//Debug.Log("Success " + BASE + frsting + scnding + PlayerPTN.NAME);
	}
	//Crafting Function
		
	
		
		public void giveHero()
		{
			string buttonname = EventSystem.current.currentSelectedGameObject.name;
			StatClass Hero = new StatClass();
			for(int x = 0; x < 3;x++)
			{
				if(Heroes[x].stats.NAME == buttonname)
				{
					Hero = Heroes[x].stats;
					break;
				}
			}	
			if(haspotion == true)
			{
			UsePotion(Hero, PlayerPTN);
			}
		}
		
		
		
		//Use Potion on Hero
		public void UsePotion(StatClass Hero, StatClass Potion)
		{
			if(Potion.STATUS == "POTION")
			{
				Hero.HP += Potion.HP;				
				if(Hero.HP > Hero.MaxHP)
				{
					Hero.HP = Hero.MaxHP;
				}
				
			}
			else if(Potion.STATUS == "PSN")
			{	
				if(Hero.STATUS == "PSN")
					{
					Hero.STATUS = "NA";
					}
				Hero.HP += Potion.HP;
				Hero.PWR += Potion.PWR;
				Hero.BNSPWR = Potion.PWR;
				if(Hero.HP > Hero.MaxHP)
					{
						Hero.HP = Hero.MaxHP;
					}
			}
			else if(Potion.STATUS == "STN")
			{	
				if(Hero.STATUS == "STN")
					{
					Hero.STATUS = "NA";
					}
				Hero.HP += Potion.HP;
				Hero.PWR += Potion.PWR;
				Hero.BNSPWR = Potion.PWR;
				if(Hero.HP > Hero.MaxHP)
					{
						Hero.HP = Hero.MaxHP;
					}
			}
			else if(Potion.STATUS == "CNF")
			{	
				if(Hero.STATUS == "CNF")
					{
					Hero.STATUS = "NA";
					}
				Hero.HP += Potion.HP;
				Hero.PWR += Potion.PWR;
				Hero.BNSPWR = Potion.PWR;
				if(Hero.HP > Hero.MaxHP)
					{
						Hero.HP = Hero.MaxHP;
					}
			}
			else if(Potion.STATUS == "ATK")
			{
				Hero.PWR += Potion.PWR;
				Hero.BNSPWR = Potion.PWR;
			}
			else if(Potion.STATUS == "SPD")
			{
				for(int x = 0; x < 3;x++)
			{
				if(Heroes[x].stats.NAME == Hero.NAME)
				{
					Heroes[x].stats.TIMER -= Potion.PWR;
					break;
				}
			}	
				
			}	
			Destroy (_instance);
			haspotion = false;
			PlayerPTN = null;
			GameObject theBelt = GameObject.Find("Belt");
			Image[] oldimages = theBelt.gameObject.GetComponentsInChildren<Image>(true);
				for(int x = 0; x < oldimages.Length; x++)
				{
					if(x%2==1)
					{
						oldimages[x].gameObject.SetActive(false);
					}
				}
			GameObject theitem = theBelt.gameobject.transform.Find(whichBelt); 
			
			if(whichBelt == "1")
			{
				GameObject theitem = theBelt.transform.Find("1");
			}
			else if(whichBelt == "2")
			{
				GameObject theitem = theBelt.transform.Find("2");
			}
			if(whichBelt == "3")
			{
				GameObject theitem = theBelt.transform.Find("3");
			}
			theitem.GetComponent<Image>.sprite = beltDefault;
			
		}
		//Use Potion on Hero
		
		//Mix Button
		public void OnMix()
		{
		
			for (int y = 0; y < 3; y++)
			{
				for(int x = 0; x < invcount.Length; x++)
				{
					if(Item[0] == null || Item[1] == null)
					{
						cancraft = false;
						Debug.Log("Select More Ingredients");
						return;
					}
					else if(PlayerInv[x] == Item[y])
					{
						if(invcount[x] > 0)
						{
							cancraft = true;
							Debug.Log(PlayerInv[x] + invcount[x]);
						}
						else
						{
							cancraft = false;
							Debug.Log("Not Enough " + Item[y]);
							return;
						}
					}
				}
			}
			if(haspotion == false && cancraft == true && cauldronCD <= 0 )
			{
			Debug.Log(Item[0] + Item[1] + Item[2]);
			Craft(Item[0],Item[1],Item[2]);
			

			
			
			_instance = Instantiate(POTIONprefab);
			_instance.transform.SetParent(cauldron);
			_instance.transform.localPosition = new Vector2(1f,1f);
			haspotion = true;
			Debug.Log("You made a " + PlayerPTN.NAME);
				for (int x = 0 ; x < 3; x++)
			{
				Item[x] = null;
				Box[x].gameObject.SetActive(false);
				GameObject unselect = GameObject.Find("Selected");
				
				if(unselect != null)
				{
					unselect.gameObject.SetActive(false);
				}
				
			}
			//need visual indication for how much ingredients was used. (Eg, "-1" floating over used items or images of used items moving into the cauldron)
			}
			else if(haspotion == true)
			{
				//need to be replace with visual indicators
				Debug.Log("Plz use potion");
			}
			else if(cauldronCD > 0)
			{
				//need to be replace with visual indicators
				Debug.Log("Please wait " + cauldronCD + " before crafting a new potion");
			}
			else
			{
				Debug.Log("sumthing wrong?" + haspotion + cauldronCD + cancraft);
			}
		}
		//Mix Button
		
		//add items from drops
		public void DropStuff()
		{
			int IsDrop = 0;
			int DropItem;
			
			IsDrop = Random.Range(1,Droprate);
			if(IsDrop<=10)
			{
				DropItem = Random.Range(0,8);
				invcount[DropItem]++;
				Droprate = 30;
				//instatitiate dropped item
				
			}
			else
			{
				Droprate -=3;
			}
		}
		//add items from drop
		
		//shelf stuff
		public void itemSelect()
		{
			
			string name = EventSystem.current.currentSelectedGameObject.name;
			Image[] images = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Image>(true);
			Image theimage = images[1];
			
			StatClass itemselect = getitembyID(name);
			if(itemselect.STATUS == "BASE")
			{
				if (Item[0] != null && Item[0] != itemselect.NAME)
				{
					GameObject unselect = GameObject.Find(Item[0]);
					Image[] oldimages = unselect.gameObject.GetComponentsInChildren<Image>();
					Image oldimage = oldimages[1];
					oldimage.gameObject.SetActive(false);				
					theimage.gameObject.SetActive(true);
					Debug.Log(itemselect.NAME + " is seleceted");
					Item[0] = itemselect.NAME;
					//Box[0].gameObject.SetActive(true);
					//Box[0].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else if(Item[0] == itemselect.NAME)
				{
					theimage.gameObject.SetActive(false);
					Item[0] = null;
					//Box[0].gameObject.SetActive(false);
					//Box[0].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else
				{
					theimage.gameObject.SetActive(true);
					Item[0] = itemselect.NAME;
					//Box[0].gameObject.SetActive(true);
					//Box[0].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}

			}
			else if(itemselect.STATUS == "FIRST")
			{
				if (Item[1] != null && Item[1] != itemselect.NAME)
				{
					GameObject unselect = GameObject.Find(Item[1]);
					Image[] oldimages = unselect.gameObject.GetComponentsInChildren<Image>();
					Image oldimage = oldimages[1];
					oldimage.gameObject.SetActive(false);				
					theimage.gameObject.SetActive(true);
					Debug.Log(itemselect.NAME + " is seleceted");
					Item[1] = itemselect.NAME;
					//Box[1].gameObject.SetActive(true);
					//Box[1].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else if(Item[1] == itemselect.NAME)
				{
					theimage.gameObject.SetActive(false);					
					Item[1] = null;
					//Box[1].gameObject.SetActive(false);
					//Box[1].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else
				{
					theimage.gameObject.SetActive(true);
					Item[1] = itemselect.NAME;
					//Box[1].gameObject.SetActive(true);
					//Box[1].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
			}
			else if(itemselect.STATUS == "SECOND")
			{
				if (Item[2] != null && Item[2] != itemselect.NAME)
				{
					GameObject unselect = GameObject.Find(Item[2]);
					Image[] oldimages = unselect.gameObject.GetComponentsInChildren<Image>();
					Image oldimage = oldimages[1];
					oldimage.gameObject.SetActive(false);				
					theimage.gameObject.SetActive(true);
					Debug.Log(itemselect.NAME + " is seleceted");
					Item[2] = itemselect.NAME;
					//Box[2].gameObject.SetActive(true);
					//Box[2].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else if(Item[2] == itemselect.NAME)
				{
					theimage.gameObject.SetActive(false);
					Item[2] = null;
					//Box[2].gameObject.SetActive(false);
					//Box[2].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else
				{
					theimage.gameObject.SetActive(true);
					Item[2] = itemselect.NAME;
					//Box[2].gameObject.SetActive(true);
					//Box[2].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
			}	
		}
		
		
		//Potion Belt
		public void potionBelt()
		{
			//setactive belt image
			Image[] images = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Image>(true);
			Image theimage = images[1];
			if(whichBelt == null)
			{
				whichBelt = EventSystem.current.currentSelectedGameObject.name;
			}
			else
			{
				GameObject unselect = GameObject.Find("Belt");
				Image[] oldimages = unselect.gameObject.GetComponentsInChildren<Image>();
				for(int x = 0; x < oldimages.Length; x++)
				{
					if(x%2==1)
					{
						oldimages[x].gameObject.SetActive(false);
					}
				}
				whichBelt = EventSystem.current.currentSelectedGameObject.name;
			}
			int num = int.Parse(whichBelt);
			
			//to use potion
			if(PlayerPTN == null)
			{
				//select potion from belt
				if(Belt[num] != null)
				{
					theimage.gameObject.SetActive(true);
					haspotion = true;
					PlayerPTN = Belt[num];
					//thisselected = true;
					POTIONprefab.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
				}
			}
			else
			{
				//to add potion to belt
				if(Belt[num] == null)
				{
					Belt[num] = PlayerPTN;
					haspotion = false;
					PlayerPTN = null;
					this.GetComponent<Image>().sprite = POTIONprefab.GetComponent<Image>().sprite;
					Destroy(_instance);
				}
			}			
		}
		
		
		
		//end inventory
		public void endInv()
		{
			for (int x = 0; x < invcount.Length; x++)
			{
				for (int y = 0; y< Player.invmanager.items.Length;y++)
				{
					if(Player.invmanager.items[y] == PlayerInv[x])
					{
						Player.invmanager.count[y] = invcount[x];
						invmanager.count[y] = invcount[x];
					}
				}
			}
		}
}