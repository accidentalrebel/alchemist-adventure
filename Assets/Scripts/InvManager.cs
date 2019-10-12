using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager 
 {
	public string[] items = {"Water", "Oil", "Wine", "Herb", "Mushroom","Venom"};
	public int[] count = {5,5,5,5,5,5};
	
	
	public void buyItem(string name)
	{
		for(int x = 0; x <6; x++)
		{
			if(name == items[x])
			{
				count[x] ++;
			}
		}
	}
	
	public void setCount(string name, int amount)
	{
		for(int x = 0; x <6; x++)
		{
			if(name == items[x])
			{
				count[x] = amount;
			}
		}
	}
	
}
