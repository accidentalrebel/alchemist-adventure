using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour {
	
	public Stats stats;
	public Hero hero;
	
	//UI
	
	//Starting Values
	public Hero[] heroes = new Hero[4];
	

	// Use this for initialization
	void Start () {
		heroes[0] = new Hero("Mage", 3, 5, false, false);
		heroes[1] = new Hero("Archer", 3, 5, false, false);
		heroes[2] = new Hero("Monk", 3, 5, false, false);
		heroes[3] = new Hero("Knight", 3, 5, false, false);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
