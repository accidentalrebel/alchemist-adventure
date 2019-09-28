using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero_Archer : Battle_npc {
	
	public TMP_Text hplabel; //for the HP Bar
	
	void Start () {
		
		Setup(new StatClass ("Archer", 5, 6, "NA", 10f, 0, 5));
		
		Debug.Log("archer ready");
	}
	
	void Update () {
		base.Update();
		
		hplabel.text = "HP " + stats.HP + "/" + stats.MaxHP; 

	}
}
