using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // マウスの感度
    public Transform playerBody;  // プレイヤーのトランスフォーム

    float xRotation = 0f;

    void Start()
    {
        // マウスカーソルをロックして非表示にする（任意の設定）
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        cameramove();
    }

    void cameramove()
    {
        // マウス左クリックでカメラを動かす
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 上下方向の回転角度を制限する

            // カメラの上下方向の回転
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // プレイヤーの体を左右に回転させる
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}