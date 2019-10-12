using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using TMPro;

public class PrepPhase : MonoBehaviour {

    public Player player;
    public Ingredients dataIngredients;
    public TMP_Text[] IngredientName;
    public TMP_Text[] IngredientPrice;
    public TMP_Text goldValue;


    public int goldTotal;
    public string[] ingredientList = { "Water", "Oil", "Wine" };
    List<string> displayIngredients;


    // Use this for initialization
    void Start () {
        goldTotal = player.gold;
        goldValue.text = goldTotal.ToString();
       

        displayIngredients = new List<string>();
        displayIngredients = Enumerable.ToList(Enumerable.Distinct(displayIngredients)); 


        Ingredients[] ingredients = new Ingredients[3];
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


      
        for (int priceIndex = 0; priceIndex < ingredients.Length; priceIndex++)
        {
            IngredientPrice[priceIndex].text = ingredients[priceIndex].ingredientPrice.ToString();
        }
  



  
        


    }

  public void loadBattle()
    {
        SceneManager.LoadScene("BattleSystem");
    }
}
