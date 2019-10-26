using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero_Knight : Battle_npc {
	
	public TMP_Text hplabel; //for the HP Bar

	void Start () {
		ailments = new Ailments ();
		//Name, HP, PWR, STATUS, SPD, PRICE, MAXHP
		Setup(new StatClass ("Knight", 6, 5, "NA", 15f, 0, 6));

	}
	
	void Update () {
		base.Update();
		
		if (stats.HP <= 0) {
			hplabel.text = "HP " + 0 + "/" + stats.MaxHP;
		}
		if (stats.HP >= 1) {
			hplabel.text = "HP " + stats.HP + "/" + stats.MaxHP;
		}
	}
}
