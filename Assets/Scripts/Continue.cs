using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Continue : MonoBehaviour {

    public void loadRewards()
    {
        SceneManager.LoadScene("RewardScreen");
    }


    public void loadQuest()
    {
        SceneManager.LoadScene("QuestMenu");
    }


}
