using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Snake : Battle_npc {
	
	//For the future HP Bar
	//public TMP_Text hplabel;

	void Start () {
		
		Setup(new StatClass ("Snake", 20, 2, "NA", 18f, 0, 20));
		
		Debug.Log("snake ready");
	}
	
	void Update () {
		base.Update();
		
		//hplabel.text = "HP " + stats.HP + "/" + stats.MaxHP;
		
	}
}
