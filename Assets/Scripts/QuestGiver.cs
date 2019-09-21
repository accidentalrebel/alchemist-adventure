using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour {

    public Quest quest;

    public QuestManager questManager;

    public GameObject questWindow;

    public int fameValue;

     public void Start()
    {
         fameValue = PlayerPrefs.GetInt("fame");
    }
    


    

    public TMP_Text questTitle;
    public TMP_Text questDescription;
    public TMP_Text fameReward;
    public TMP_Text goldReward;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        questTitle.text = quest.questName;
        questDescription.text = quest.questDesc;
        fameReward.text = quest.fameReward.ToString();
        goldReward.text = quest.goldReward.ToString();


    }
       
    public void QuestAccepted()
    {
        if (fameValue >= 0)
        {
            questWindow.SetActive(false);
            quest.progress = Quest.QuestProgress.ACCEPTED;
        }

        else Debug.Log("Not enough Fame");

    }

    public void QuestDeclined()
    {
        questWindow.SetActive(false);
        quest.progress = Quest.QuestProgress.DECLINED;

    }
}
