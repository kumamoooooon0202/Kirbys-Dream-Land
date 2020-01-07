using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneChange : MonoBehaviour
{
    private bool doorFlag;

    void Start()
    {
        
    }

    void Update()
    {
        if (doorFlag && Input.GetKeyDown(KeyCode.W))
        {
            SceneChange();
        }
    }

    /// <summary>
    /// 現在のシーンの名前を取得し、次のシーンに遷移する
    /// </summary>
    private void SceneChange()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameScene1-1":
                SceneManager.LoadScene("GameScene1-2");
                break;
        }
    }

    /// <summary>
    /// プレイヤーとドアが触れているかどうかの判定
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorFlag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorFlag = false;
        }
    }
}
