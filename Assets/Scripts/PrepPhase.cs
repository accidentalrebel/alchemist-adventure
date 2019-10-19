using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using TMPro;

public class PrepPhase : MonoBehaviour {

    public Player player;
    
    public TMP_Text[] IngredientName;
    public TMP_Text[] IngredientPrice;
    public TMP_Text goldValue;
    public int goldTotal;

    public string[] ingredientList = { "Water", "Oil", "Wine" };
    List<string> displayIngredients;

    public Ingredients[] ingredients = new Ingredients[6];
    public InvManager invmanager;



    // Use this for initialization
    public void Start()
    {
        goldTotal = player.gold;
        goldValue.text = goldTotal.ToString();
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
        ingredients[3].ingredientPrice = 7;
        ingredients[3].ingredientQuantity = 1;

        ingredients[4] = new Ingredients();
        ingredients[4].ingredientName = "Mushroom";
        ingredients[4].ingredientPrice = 7;
        ingredients[4].ingredientQuantity = 1;

        ingredients[5] = new Ingredients();
        ingredients[5].ingredientName = "Venom";
        ingredients[5].ingredientPrice = 7;
        ingredients[5].ingredientQuantity = 1;



        int count = 0;
        while (count < 3)
        {
            string random = ingredients[Random.Range(0, ingredients.Length)].ingredientName;
            if (!displayIngredients.Contains(random))
            {
                IngredientName[count].text = random;
                displayIngredients.Add(IngredientName[count].text);
                Debug.Log("Item Added " + IngredientName[count].text);
                count++;
            }

        }

        /* for (int priceIndex = 0; priceIndex < ingredients.Length; priceIndex++)
    {
        IngredientPrice[priceIndex].text = ingredients[priceIndex].ingredientPrice.ToString();
    }*/

    }

    public void pressBuy() {
            string whichitem = EventSystem.current.currentSelectedGameObject.name;
            int detectitem = int.Parse(whichitem);

            invmanager.buyItems(IngredientName[detectitem].text);
        }
    
  

    

  public void loadBattle()
    {
        SceneManager.LoadScene("BattleSystem");
    }
}
