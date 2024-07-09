using UnityEngine;
using System.Collections.Generic;
 
public class AssistPointManager : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public GameObject goal;
    // public string assistPointTag = "AssistPoint"; // AssistPointのタグ
    public string goalTag = "Goal"; // Goalのタグ
    public float displayDuration = 3.0f; // 表示時間（秒）
    public AudioClip assistSE; // AssistPointを表示する際に再生するSE
    private List<KeyValuePair<float, string>> distancesList = new List<KeyValuePair<float, string>>();

 
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        goal=GameObject.FindGameObjectWithTag("Goal");

        GameObject[] AssistPoints=GameObject.FindGameObjectsWithTag("AssistPoint");

        foreach(GameObject apbook in AssistPoints){
            apbook.SetActive(false);
        }
        MeasurePlayerDistance(AssistPoints);
    }

    void Update(){

    }

    void MeasurePlayerDistance(GameObject[] AssistPoints){
        foreach(GameObject assistPoint in AssistPoints){
            float distance=Vector3.Distance(assistPoint.transform.position, player.transform.position);
            distancesList.Add(new KeyValuePair<float,string>(distance,assistPoint.name));
        }

        distancesList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
        foreach(var pair in distancesList){
            Debug.Log("Distance: " + pair.Key + ", Object: " + pair.Value);
        }   

    }

    void MeasureGoalDistance(){

    }
}