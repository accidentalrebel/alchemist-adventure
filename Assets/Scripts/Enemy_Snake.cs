using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Snake : Battle_npc {
	
	//For the future HP Bar
	//public TMP_Text hplabel;

	void Start () {
		
		Setup(new StatClass ("Snake", 100, 2, "NA", 18f, 0, 20));
		
		Debug.Log("snake ready");
	}
	
	void Update () {
		base.Update();
		
		/*if (stats.HP <= 0) {
			hplabel.text = "HP " + 0 + "/" + stats.MaxHP;
		}
		if (stats.HP >= 1) {
			hplabel.text = "HP " + stats.HP + "/" + stats.MaxHP;
		}
		*/
	}
}
