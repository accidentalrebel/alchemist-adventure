using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Mage : Battle_npc {
	
	public StatClass stats;

	// Use this for initialization
	void Start () {
		
		Setup(new StatClass ("Mage", 3, 7, "NA", 20f, 0));
		
		Debug.Log("mage ready");
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
