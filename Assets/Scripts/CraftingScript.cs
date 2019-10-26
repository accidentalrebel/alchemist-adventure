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

	string[] PlayerInv = {"Water", "Oil", "Wine", "Herb", "Mushroom","Venom"};
	int[] invcount = new int[6];
	StatClass PlayerPTN;
	bool haspotion = false;
	bool cancraft = true;
	
	//For Potion instance
	private GameObject _instance;
	public GameObject POTIONprefab;
	public Transform cauldron;
	public Sprite HP;
	public Sprite ATK;
	public Sprite CURE;

	//For selecting Ingredient
	public TMP_Text[] itemText = new TMP_Text[3];
	public Image[] itemImage = new Image[3];
	string[] Item = new string[3];
	public GameObject[] Box = new GameObject[3];
	//for shelf
	public TMP_Text[] itemcount;
	private GameObject childObj;
	public bool activeSelf;
	
	//gethero
	public Battle_npc[] Heroes = new Battle_npc[3];

	
	// Use this for initialization
	void Start () {	
        items = new List<StatClass>();

        items.Add(new StatClass("Water", 0, 0, "BASE", 0, 2));
        items.Add(new StatClass("Oil", 0, 0, "BASE", 0, 7));
        items.Add(new StatClass("Wine", 0, 0, "BASE", 0, 5));
        items.Add(new StatClass("Herb", 2, 0, "FIRST", 0, 5));
        items.Add(new StatClass("Venom", 0, 0, "SECOND", 0, 4));
        items.Add(new StatClass("Mushroom", 0, 1, "FIRST", 0, 8));
		items.Add(new StatClass("WTRhrb", 2, 0, "POTION", 3, 0));
		items.Add(new StatClass("OILhrb", 2, 0, "POTION", 4, 0));
		items.Add(new StatClass("WINhrb", 4, 0, "POTION", 5, 0));
		items.Add(new StatClass("WTRpow", 0, 2, "ATK", 3, 0));
		items.Add(new StatClass("OILpow", 0, 2, "ATK", 4, 0));
		items.Add(new StatClass("WINpow", 0, 3, "ATK", 5, 0));
		items.Add(new StatClass("WTRVen", 0, 0, "PSN", 3, 0));
		items.Add(new StatClass("WINVen", 0, 0, "PSN", 4, 0));
		items.Add(new StatClass("OILVen", 0, 0, "PSN", 5, 0));
		
		//set invcount from prepphase
		for (int x = 0; x < 6; x++)
		{
			for (int y = 0; y< 6;y++)
			{
			if(Player.invmanager.items[y] == PlayerInv[x])
			{
				invcount[x]= Player.invmanager.count[y];
			}
			}
		}

			
	}
	
	void Update () {
			/*player inventory
		for(int x = 0; x < 5; x++)
		{
			Debug.Log(PlayerInv[x]);
			Debug.Log(invcount[x]);
		}*/
		
			//need visual indicator of timer
		
		cauldronCD -= Time.deltaTime;
		
				
		//shelf? need to get parent name
		for(int x = 0; x < 6; x++)
		{
			itemcount[x].text = invcount[x].ToString();
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
	
	//asign potion
    public void Craft(string BASE, string frsting,string scnding)
    {
		StatClass potion = null;
      if(BASE == "Water")
		{
			if(scnding == "Venom" && frsting != null)
			{
			potion = getitembyID("WTRVen");
			POTIONprefab.GetComponent<Image>().sprite = CURE;
			invcount[5] -=1;
			for(int x = 0; x < 6;x++)
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
			 
		invcount[0] -=1;
		}
		else if(BASE == "Wine")
		{
			if(scnding == "Venom" && frsting == "Herb")
			{
				potion = getitembyID("WINVen");
				potion.HP = 1;
				POTIONprefab.GetComponent<Image>().sprite = CURE;
				invcount[5] -=1;
				invcount[3] -=1;
			
			}
			else if(scnding == "Venom" && frsting == "Mushroom")
			{
				potion = getitembyID("WINVen");
				potion.PWR = 1;
				POTIONprefab.GetComponent<Image>().sprite = CURE;
				invcount[5] -=1;
				invcount[4] -=1;
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
			 
		invcount[2] -=1;  
		}
		else if(BASE == "Oil")
		{
			//oil need visual indicator to inform player if he got a bad or good result
			int oilRDM;
			oilRDM = Random.Range(0,2);
		  
		 if(scnding == "Venom" && frsting != null)
		{
			potion = getitembyID("OILVen");
			if(oilRDM == 0)
			{
			potion.STATUS = "PSN";
			if(frsting == "Herb")
				{
					potion.HP = -1;
					invcount[3] -=1;
				}
				else if(frsting == "Mushroom")
				{
					potion.PWR = -1;
					invcount[4] -= 1;
				}
			}
			else if(oilRDM == 1)
			{
			potion.STATUS = "PSN";
			if(frsting == "Herb")
				{
					potion.HP = 0;
					invcount[3] -=1;
				}
				else if(frsting == "Mushroom")
				{
					potion.PWR = 0;
					invcount[4] -= 1;
				}
			}
			else if(oilRDM == 2)
			{
			potion.STATUS = "PSN";
				if(frsting == "Herb")
				{
					potion.HP = 1;
					invcount[3] -=1;
				}
				else if(frsting == "Mushroom")
				{
					potion.PWR = 1;
					invcount[4] -= 1;
				}
			}
			POTIONprefab.GetComponent<Image>().sprite = CURE;
			invcount[5] -=1;
		}
		else if(frsting == "Herb")
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
			potion.HP = 3;
			}
			POTIONprefab.GetComponent<Image>().sprite = HP;
			invcount[3] -=1;
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
			potion.PWR = 3;
			}
			POTIONprefab.GetComponent<Image>().sprite = ATK;
			invcount[4] -=1;
		}
		 
			
		
		
		invcount[1] -=1;
		}
		//need function to give hero script the potion
		PlayerPTN = potion;		
		//cauldron cooldown
		cauldronCD = potion.SPD;

		

		//Debug.Log("Success " + BASE + frsting + scnding + PlayerPTN.NAME);
	}
		
	
		//temporarily disabled until merge; must be triggered in Hero list
		
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
			UsePotion(Hero, PlayerPTN);
			
		}
		
		//temp use potion
		public void tempUse()
		{
			Destroy(_instance);
			haspotion = false;
		}
		
		
	
		public void UsePotion(StatClass Hero, StatClass Potion)
		{
			if(Potion.STATUS == "POTION")
			{
				Hero.HP += Potion.HP;				
				if(Hero.HP > Hero.MaxHP)
				{
					Hero.HP = Hero.MaxHP;
				}
				Destroy (_instance);
				haspotion = false;
			}
			else if(Potion.STATUS == "PSN")
			{
				Hero.STATUS = "NA";
				Hero.HP += Potion.HP;
				Hero.PWR += Potion.PWR;
				if(Hero.HP > Hero.MaxHP)
				{
					Hero.HP = Hero.MaxHP;
				}
				Destroy (_instance);
				haspotion = false;
				
			}
			/*else if(Potion.STATUS == "PSNRES")
			{
				Hero.STATUS = "PSNRES";
				//resistance only lasts 1 turn
			}	*/			
			else if(Potion.STATUS == "ATK")
			{
				Hero.PWR += Potion.PWR;
				Destroy (_instance);
				haspotion = false;
				Hero.BNSPWR = Potion.PWR;
				//need variable to reset PWR to normal after next attack
			}
			/*else if(Potion.STATUS == "NA")
			{
				Destroy (_instance);
				Debug.Log("Nothing happened");
			}*/
			
		}
		
		
		
		public void OnMix()
		{
		
			for (int y = 0; y < 3; y++)
			{
				for(int x = 0; x < 6; x++)
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
		
		//add items from drops
		public void additem(string name)
		{
			for (int y = 0; y< 6;y++)
			{
			if(name == PlayerInv[y])
			{
				invcount[y]++;
			}
			}
		}

		
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
					Box[0].gameObject.SetActive(true);
					Box[0].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else if(Item[0] == itemselect.NAME)
				{
					theimage.gameObject.SetActive(false);
					Item[0] = null;
					Box[0].gameObject.SetActive(false);
					Box[0].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else
				{
					theimage.gameObject.SetActive(true);
					Item[0] = itemselect.NAME;
					Box[0].gameObject.SetActive(true);
					Box[0].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
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
					theimage.gameObject.SetActive(true);
					Debug.Log(itemselect.NAME + " is seleceted");
					Item[1] = itemselect.NAME;
					Box[1].gameObject.SetActive(true);
					Box[1].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else if(Item[1] == itemselect.NAME)
				{
					theimage.gameObject.SetActive(false);					
					Item[1] = null;
					Box[1].gameObject.SetActive(false);
					Box[1].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else
				{
					theimage.gameObject.SetActive(true);
					Item[1] = itemselect.NAME;
					Box[1].gameObject.SetActive(true);
					Box[1].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
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
					theimage.gameObject.SetActive(true);
					Debug.Log(itemselect.NAME + " is seleceted");
					Item[2] = itemselect.NAME;
					Box[2].gameObject.SetActive(true);
					Box[2].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else if(Item[2] == itemselect.NAME)
				{
					theimage.gameObject.SetActive(false);
					Item[2] = null;
					Box[2].gameObject.SetActive(false);
					Box[2].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
				else
				{
					theimage.gameObject.SetActive(true);
					Item[2] = itemselect.NAME;
					Box[2].gameObject.SetActive(true);
					Box[2].GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
				}
			}	

					
				
		}
}