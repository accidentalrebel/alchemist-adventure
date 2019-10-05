using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients {
    
    public string ingredientName;
    public int ingredientPrice;
    public int ingredientQuantity;


    public void getData() { 

    Ingredients[] ingredients = new Ingredients[3];
        ingredients[0] = new Ingredients();
        ingredients[0].ingredientName = "Ingredient 1";
        ingredients[0].ingredientPrice = 2;
        ingredients[0].ingredientQuantity = 1;

        ingredients[1] = new Ingredients();
        ingredients[1].ingredientName = "Ingredient 2";
        ingredients[1].ingredientPrice = 5;
        ingredients[1].ingredientQuantity = 1;

        ingredients[2] = new Ingredients();
        ingredients[2].ingredientName = "Ingredient 3";
        ingredients[2].ingredientPrice = 7;
        ingredients[2].ingredientQuantity = 1;

    }





}
