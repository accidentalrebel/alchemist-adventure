using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Archer : Battle_npc {
	
	public StatClass stats;
	
	// Use this for initialization
	void Start () {
		
		Setup(new StatClass ("Archer", 5, 6, "NA", 10f, 0));
		
		Debug.Log("archer ready");
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
