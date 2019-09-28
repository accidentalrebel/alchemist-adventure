using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero_Mage : Battle_npc {
	
	public TMP_Text hplabel; //for the HP Bar 
	
	void Start () {
		
		Setup(new StatClass ("Mage", 3, 7, "NA", 20f, 0, 3));
		
		Debug.Log("mage ready");
	}
	
	void Update () {
		base.Update();
		
		hplabel.text = "HP " + stats.HP + "/" + stats.MaxHP;
		
	}
	
	
	
}
