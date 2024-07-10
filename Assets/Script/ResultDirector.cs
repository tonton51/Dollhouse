using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultDirector : MonoBehaviour
{
    GameObject resulttimertext;
    float resulttime;
    // Start is called before the first frame update
    void Start()
    {
            this.resulttimertext = GameObject.Find("GoalTime");
            this.resulttime=GameDirector.getGoalTime(); 
            Debug.Log(resulttime);
            this.resulttimertext.GetComponent<TextMeshProUGUI>().text = this.resulttime.ToString("F1");
    }

}
