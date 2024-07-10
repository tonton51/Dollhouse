using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    float time=0.0f;
    public static float goaltime;
    protected void Start(){
        this.timerText = GameObject.Find("Time");
    }
    // Update is called once per frame
    void Update()
    {   
        
        this.time += Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");

        bool goalflag=PlayerController.getGoalFlag();
        // goalflagがtrueならゴールシーンに遷移
        if(goalflag){
            Debug.Log("goal");
            goaltime=this.time;
            SceneManager.LoadScene("GoalScene");
        }

    }

    public static float getGoalTime() { return goaltime; }
}
