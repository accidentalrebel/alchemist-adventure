using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PrepPhase : MonoBehaviour {
    public Ingredients dataIngredients;
    public TMP_Text[] IngredientName;
    public TMP_Text[] IngredientPrice;

    public string[] ingredientList = { "Water", "Oil", "Wine" };
    List<string> displayIngredients;


    // Use this for initialization
    void Start () {
        displayIngredients = new List<string>();
        
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



        

        for (int count = 0; count < 3; count++)
        {
            
               IngredientName[count].text = ingredients[Random.Range(0, 3)].ingredientName;
               Debug.Log("test" + IngredientName[count].text);
               displayIngredients.Add(IngredientName[count].text);
            if(!displayIngredients.Contains(IngredientName[count].text))
            {
        
            }
         
        }


        /*
        for (int count = 0; count <=2; count++)
        {
            IngredientPrice[count].text = ingredients[count].ingredientPrice.ToString();
        }
        */



  



    }

  public void loadBattle()
    {
        SceneManager.LoadScene("BattleSystem");
    }
}
