using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestManager : MonoBehaviour {

    public static QuestManager questManager;
    public List<Quest> questList = new List<Quest>();
    public List<Quest> currentQuestList = new List<Quest>();
 

    /*void Awake()
    {
        if(questManager == null)
        {
            questManager = this;
        }

        else if(questManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }*/


    #region QuestStatus

    //Accept Quest
    public void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {

             if (questList[i].ID == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
             {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;

             }
            
        }
    }

    //Abandon Quest
    public void AbandonQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {

            if (currentQuestList[i].ID == questID && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quest.QuestProgress.AVAILABLE;
                currentQuestList[i].questObjectiveCount = 0;
                currentQuestList.Remove(currentQuestList[i]);


            }

        }
    }



    //Complete Quest
    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].ID == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);
            }

        }
    }

    #endregion

    #region QuestChecking
    public bool RequestAvailabeQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].ID == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }


    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].ID == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false; 
    }


    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].ID == questID && questList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }

    #endregion



}
