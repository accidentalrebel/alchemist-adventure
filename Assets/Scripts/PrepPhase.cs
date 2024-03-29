﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using TMPro;

public class PrepPhase : MonoBehaviour {

    public Player player;
    
    public TMP_Text[] IngredientName;
    public TMP_Text[] IngredientPrice;
    public TMP_Text goldValue;
    public int goldTotal;

    public Image[] imageIcons = new Image[6];
    public GameObject[] icons = new GameObject[3];
    public string[] ingredientList = { "Water", "Oil", "Wine" };
    List<string> displayIngredients;

    public Ingredients[] ingredients = new Ingredients[6];
    public InvManager invmanager;

	//for shelf
	public TMP_Text[] itemcount;
	//for Rewardscreen
	public bool allGold = false;
	public Text RewardButton;

    // Use this for initialization
    public void Start()
    {
        goldTotal = player.gold;
        goldValue.text = player.gold.ToString();

        displayIngredients = new List<string>();
        displayIngredients = Enumerable.ToList(Enumerable.Distinct(displayIngredients));



        ingredients[0] = new Ingredients();
        ingredients[0].ingredientName = "Water";
        ingredients[0].ingredientPrice = 2;
        ingredients[0].ingredientQuantity = 1;

        ingredients[1] = new Ingredients();
        ingredients[1].ingredientName = "Wine";
        ingredients[1].ingredientPrice = 5;
        ingredients[1].ingredientQuantity = 1;

        ingredients[2] = new Ingredients();
        ingredients[2].ingredientName = "Oil";
        ingredients[2].ingredientPrice = 7;
        ingredients[2].ingredientQuantity = 1;

        ingredients[3] = new Ingredients();
        ingredients[3].ingredientName = "Herb";
        ingredients[3].ingredientPrice = 5;
        ingredients[3].ingredientQuantity = 1;

        ingredients[4] = new Ingredients();
        ingredients[4].ingredientName = "Mushroom";
        ingredients[4].ingredientPrice = 4;
        ingredients[4].ingredientQuantity = 1;

        ingredients[5] = new Ingredients();
        ingredients[5].ingredientName = "Venom";
        ingredients[5].ingredientPrice = 8;
        ingredients[5].ingredientQuantity = 1;



        int count = 0;
        while (count < 3)
        {
            
            int iconOrder = (Random.Range(0, ingredients.Length));
            Ingredients ingredient = ingredients[iconOrder];
            string random = ingredient.ingredientName;
            
            if (!displayIngredients.Contains(random))
            {
                icons[count].GetComponent<Image>().sprite = imageIcons[iconOrder].sprite;
                IngredientName[count].text = random;
                IngredientPrice[count].text = ingredient.ingredientPrice.ToString();
                displayIngredients.Add(IngredientName[count].text);
                Debug.Log("Item Added " + IngredientName[count].text);
                count++;
            }
           

        }



    }

    public void pressBuy() {
		
            string whichitem = EventSystem.current.currentSelectedGameObject.name;
            int detectitem = int.Parse(whichitem);
            
			for (int x = 0; x < 6; x++)
			{

            if (IngredientName[detectitem].text == ingredients[x].ingredientName && player.gold-ingredients[x].ingredientPrice > 0)
            {
					invmanager.buyItems(IngredientName[detectitem].text);
					player.gold -= ingredients[x].ingredientPrice;

			}
			else
			{
				Debug.Log("Not enough Gold");	
			}
				
			}
            Player.invmanager = invmanager;
			
            
        }
    
  	void Update () {

		//shelf? need to get parent name
		for(int x = 0; x < 6; x++)
		{
			itemcount[x].text = invmanager.count[x].ToString();
		}
		
		goldValue.text = 
		player.gold.ToString();
		if(allGold == false)
		{
		    if ( RewardButton != null ) {
			RewardButton.text = "Convert to Gold";
		    }
		}
		else
		{
		    if ( RewardButton != null ) {
			RewardButton.text = "Back to Menu";
		    }
		}
	}

  public void loadBattle()
    {
        SceneManager.LoadScene("BattleSystem");
		allGold = false;
    }
	
	public void EndButton()
	{
		if(allGold == false)
		{
			for(int x = 0; x < 6; x++)
		{
			player.gold += (ingredients[x].ingredientPrice*invmanager.count[x]);
			invmanager.count[x] = 0;
			allGold = true;
			
		}
		Player.invmanager = invmanager;
		}
		else
		{
			SceneManager.LoadScene("QuestMenu");
		}
	}

}
