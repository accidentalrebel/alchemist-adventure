using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Knight : Npc {
	
	public StatClass stats;

	// Use this for initialization
	void Start () {
		
		Setup(new StatClass ("Knight", 6, 5, "NA", 15f, 0));
		
		Debug.Log("knight ready");
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
