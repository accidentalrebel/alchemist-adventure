using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

	//Status
	public string name;
	public int hp;
	public int power;
	public bool stun;
	public bool poison;
	
	public Stats(string name, int hp, int power, bool stun, bool poison) {
			this.name = name;
			this.hp = hp;
			this.power = power;
			this.stun = stun;
			this.poison = poison;
		}
}
