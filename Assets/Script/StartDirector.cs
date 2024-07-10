using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    // 1人プレイ用
    public void Playstart(){
        Debug.Log("シーン遷移");
         SceneManager.LoadScene("GameScene");
    }

}
