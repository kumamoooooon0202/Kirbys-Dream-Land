using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private Scene loadScene;
    [SerializeField] private Player player;
    private int playerHp;

    void Start()
    {
        loadScene = SceneManager.GetActiveScene();
        player = GetComponent<Player>();
        playerHp = player.CharacerHp();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// リスタート
    /// </summary>
    private void ReStart()
    {
        if (playerHp == 0 && Player.life != 0)
        {
            // Fadeinとか使いたい
            SceneManager.LoadScene(loadScene.name);
        }
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    private void GameOver()
    {
        if (playerHp == 0 && Player.life == 0 || Player.life < 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
