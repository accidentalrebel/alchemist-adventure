using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ailments {
	
	public int poisonDamage = 1;
	
	public void poisonAttack (Battle_npc target) {
		int roll = Random.Range(0, 100);
		if (roll > 10) {
			target.stats.STATUS = "PSN";
			Debug.Log("Snake poisons "+ target.stats.NAME);
			
		}
	}
	
	public void isPoisoned (Battle_npc hero) {
		Debug.Log("I'm poisoned!");
		hero.stats.HP -= poisonDamage;
		hero.takePoisonDamage(hero);
	}
	
	
}
