using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Player player;
    private EnemyAudio enemyAudio;
    public EnemyStatus myEnemyStatus;

    public enum EnemyStatus
    {
        empty,
        nomal,
        beam,
        fire,
        cutter,
        sword
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        enemyAudio = GetComponent<EnemyAudio>();
    }

    /// <summary>
    /// 敵の死
    /// </summary>
    public void DeathEnemy()
    {
        DeathEffectController.DeathEffect(gameObject.transform.position);
        enemyAudio.DamegeAudio();
        gameObject.SetActive(false);
        //Destroy(gameObject);
        TextController.AddScore();
    }

    /// <summary>
    /// 敵の当たり判定処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star" || collision.gameObject.tag == "Player")
        {
            DeathEnemy();
        }
    }
}
