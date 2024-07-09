using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlayer : MonoBehaviour
{
    Rigidbody rb;
    float speed = 2.0f;
    public GameObject playerCamera;  // プレイヤーのカメラ
    public static bool goalflag = false;

    void OnTriggerEnter(Collider other)
    {
        // ゴールに当たったら、goalflagをtrueにする
        if (other.CompareTag("Goal"))
        {
            goalflag = true;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // playerの操作
    void Update()
    {
         playermove();

    }

    void playermove(){
        if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = -transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = transform.right * speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = -transform.right * speed;
            }
    }
}
