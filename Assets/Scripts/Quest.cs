using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class Quest {

    public enum QuestProgress {NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETE, DONE, DECLINED}
    
   
    #region QuestDetails

    public int ID;
    public string questName;
    public string questDesc;
    public int backToMenu;
    public QuestProgress progress;

    


    #endregion

    #region Objectives


    public string questObjective;
    public int questObjectiveCount;
    public int questRequirement;


    #endregion

    #region Rewards

    public int fameReward;
    public int goldReward;
    public string itemReward;

    #endregion

    public void Start()
    {
        PlayerPrefs.SetInt("fame", 0);
        PlayerPrefs.SetInt("gold", 0);
    }



}
