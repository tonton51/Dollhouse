using UnityEngine;
using System.Collections.Generic;
using System.Collections;
 
public class AssistPointManager : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public GameObject goal;
    // public string assistPointTag = "AssistPoint"; // AssistPointのタグ
    public string goalTag = "Goal"; // Goalのタグ
    public float displayDuration = 3.0f; // 表示時間（秒）
    public AudioClip assistSE; // AssistPointを表示する際に再生するSE
    private AudioSource aud;
    GameObject CurrentAP;
    float time=0.0f;
    float span=3.0f;
    float apspan=3.0f;
    float aptime=0.0f;
    GameObject[] AssistPoints;
    Renderer currentrenderer;
    bool apflag=false;


 
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        goal=GameObject.FindGameObjectWithTag("Goal");

        AssistPoints=GameObject.FindGameObjectsWithTag("AssistPoint");
        this.aud = GetComponent<AudioSource>();

        foreach(GameObject apbook in AssistPoints){
            // AssistPointの子オブジェクトであるbook_close1のRendererを取得して非表示にする
            Renderer renderer = apbook.transform.Find("book_close1").GetComponent<Renderer>();
            renderer.enabled=false;
        }

    }

    void Update(){
        this.time+=Time.deltaTime;
        this.aptime+=Time.deltaTime;
        player=GameObject.FindGameObjectWithTag("Player");
        // ここを秒数指定のifにする
        GameObject[] MinAP=MeasurePlayerDistance(AssistPoints);
        // Debug.Log(time+","+apflag);
        if((time>span)&&(apflag==false)){
            // Debug.Log("表示");
            CurrentAP=MeasureGoalDistance(MinAP); // 元のやつ
            // Debug.Log(CurrentAP.name);
            currentrenderer=CurrentAP.transform.Find("book_close1").GetComponent<Renderer>();
            currentrenderer.enabled=true;
            AudioSource.PlayClipAtPoint(assistSE,CurrentAP.transform.position);
            time=0.0f;
            aptime=0.0f;
            apflag=true;
        }
        if((aptime>apspan)&&(apflag==true)){
                // Debug.Log("消去");
                currentrenderer.enabled=false;
                aptime=0.0f;
                apflag=false;
        }
        

    }

    GameObject[] MeasurePlayerDistance(GameObject[] AssistPoints){
        List<KeyValuePair<float, string>> distancesList = new List<KeyValuePair<float, string>>();
        foreach(GameObject assistPoint in AssistPoints){
            // Debug.Log(player.transform.position);
            float distance=Vector3.Distance(assistPoint.transform.position, player.transform.position);
            distancesList.Add(new KeyValuePair<float,string>(distance,assistPoint.name));
        }

        distancesList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
         // MinAPを初期化する
        GameObject[] MinAP = new GameObject[3];

        // distancesListの上位3つのオブジェクトを取得する
        for(int i = 0; i < MinAP.Length; i++){
            GameObject foundObject = GameObject.Find(distancesList[i].Value);
            MinAP[i] = foundObject;
            //Debug.Log(i+"/"+MinAP[i]);
        }

        return MinAP;
    }

    // ゴールまでの距離を測定する
    GameObject MeasureGoalDistance(GameObject[] MinAP){
        List<KeyValuePair<float, string>> GoaldistancesList = new List<KeyValuePair<float, string>>();
        foreach(GameObject GoalAP in MinAP){
            float distance=Vector3.Distance(GoalAP.transform.position, goal.transform.position);
            GoaldistancesList.Add(new KeyValuePair<float,string>(distance,GoalAP.name));
        }
        GoaldistancesList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
        return GameObject.Find(GoaldistancesList[1].Value);
    }
}