using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private Scene loadScene;
    [SerializeField] private Player player;
    private int playerHp;
    [SerializeField] private GameObject panel;
    private float panel_a;

    void Start()
    {
        loadScene = SceneManager.GetActiveScene();
        player = FindObjectOfType<Player>();
        playerHp = player.CharacerHp();
        panel_a = panel.GetComponent<Image>().color.a;
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
            StartCoroutine("FadeOut");
            SceneManager.LoadScene(loadScene.name);
            Player.life--;
            StartCoroutine("FadeIn");
        }
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    private void GameOver()
    {
        if (playerHp == 0 && Player.life == 0 || Player.life < 0)
        {
            StartCoroutine("FadeOut");
            SceneManager.LoadScene("GameOverScene");
            StartCoroutine("FadeIn");
        }
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut()
    {
        while (panel_a < 1)
        {
            panel.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            panel_a += 0.1f;
            yield return null;
        }
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIn()
    {
        while (panel_a > 0)
        {
            panel.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
            panel_a -= 0.1f;
            yield return null;
        }
    }
}
