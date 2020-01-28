using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// 敵の死
    /// </summary>
    public void DeathEnemy()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 敵の当たり判定処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star" || collision.gameObject.tag == "Player")
        {
            DeathEffectController.DeathEffect(gameObject.transform.position);
            Destroy(gameObject);
            TextController.AddScore();
        }
    }
}
