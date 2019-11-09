using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Proceed : MonoBehaviour {

    public void loadRewards()
    {
        SceneManager.LoadScene("RewardScreen");
    }
}
