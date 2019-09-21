using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Snake : Battle_npc {
	
	public StatClass stats;

	// Use this for initialization
	void Start () {
		
		Setup(new StatClass ("Snake", 20, 2, "NA", 18f, 0));
		
		Debug.Log("snake ready");
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
