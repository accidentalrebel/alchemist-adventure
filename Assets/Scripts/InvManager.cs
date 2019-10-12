using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager 
 {
	public string[] items = {"Water", "Oil", "Wine", "Herb", "Mushroom","Venom"};
	public int[] count = new int[6];
	
	
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
	
	/*public static int Water
	{
		get
		{
			return Water;
		}
		set
		{
			Water = value;
		}
	}
		public static int Oil
	{
		get
		{
			return Oil;
		}
		set
		{
			Oil = value;
		}
	}
		public static int Wine
	{
		get
		{
			return Wine;
		}
		set
		{
			Wine = value;
		}
	}
		public static int Herb
	{
		get
		{
			return Herb;
		}
		set
		{
			Herb = value;
		}
	}
		public static int Mushroom
	{
		get
		{
			return Mushroom;
		}
		set
		{
			Mushroom = value;
		}
	}
		public static int	 Venom
	{
		get
		{
			return Venom;
		}
		set
		{
			Venom = value;
		}
	}*/
}
