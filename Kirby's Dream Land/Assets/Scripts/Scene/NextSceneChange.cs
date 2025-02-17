﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneChange : MonoBehaviour
{
    private bool doorFlag;
    void Update()
    {
        if (doorFlag && Input.GetKeyDown(KeyCode.W))
        {
            // 今回はとりあえずステージは1個
            //SceneChange();
            SceneManager.LoadScene("ClearScene");
        }
    }

    /// <summary>
    /// 現在のシーンの名前を取得し、次のシーンに遷移する
    /// </summary>
    //private void SceneChange()
    //{
    //    switch (SceneManager.GetActiveScene().name)
    //    {
    //        case "GameScene1-1":
    //            SceneManager.LoadScene("GameScene1-2");
    //            break;
    //    }
    //}

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
