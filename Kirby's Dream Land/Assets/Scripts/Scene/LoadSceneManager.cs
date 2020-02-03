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
        player = FindObjectOfType<Player>();
        playerHp = player.CharacerHp();
    }

    void Update()
    {
        if (player.DeathFlag && player.transform.position.y <= -14)
        {
            GameOver();
            ReStart();
        }
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
            Player.life--;
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
