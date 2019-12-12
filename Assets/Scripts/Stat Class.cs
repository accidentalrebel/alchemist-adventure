using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatClass
{
	
    public string NAME;
    public int HP;
    public int PWR;
    public string STATUS;
    public float SPD;
	public int PRICE;
	public int MaxHP;  //Added Max HP for HP Bars -Pam
	public float TIMER; //Added Timer -Pam
	public bool isDead; // Added Death mode -Pam
	public bool hasAttacked; //Added Attack status -Pam
	public int BNSPWR; //Added a Bonus PWR variable for buffs -Pam
	public Sprite thissprite;

		
	public StatClass()
	{
		
	}

    public StatClass(string NAME, int HP, int PWR, string STATUS, float SPD, int PRICE, int MaxHP = 0)
    {
        this.NAME = NAME;
        this.HP = HP;
        this.PWR = PWR;
        this.STATUS = STATUS;
        this.SPD = SPD;
		this.PRICE = PRICE;
		this.MaxHP = MaxHP;
    }

	
}
