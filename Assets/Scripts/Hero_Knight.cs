using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero_Knight : Battle_npc {
	
	public TMP_Text hplabel; //for the HP Bar

	void Start () {
		
		Setup(new StatClass ("Knight", 6, 5, "NA", 15f, 0, 6));
		
		Debug.Log("knight ready");
	}
	
	void Update () {
		base.Update();
		
		hplabel.text = "HP " + stats.HP + "/" + stats.MaxHP; 
	}
}
