using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatClass
{
    public string NAME;
    public int HP;
    public int PWR;
    public string STATUS;
    public int SPD;
	public int PRICE;

    public StatClass(string NAME, int HP, int PWR, string STATUS, int SPD, int PRICE)
    {
        this.NAME = NAME;
        this.HP = HP;
        this.PWR = PWR;
        this.STATUS = STATUS;
        this.SPD = SPD;
		this.PRICE = PRICE;
    }

	
}
