using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization


    public int gold;
    public int fame;
    public static InvManager invmanager;



    void Start () {
        PlayerPrefs.SetInt("fame", 0);
        PlayerPrefs.SetInt("gold", 100);

        fame = PlayerPrefs.GetInt("fame");
        gold = PlayerPrefs.GetInt("gold");
    }

    
	
}
