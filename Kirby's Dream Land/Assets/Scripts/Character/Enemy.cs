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

    void Update()
    {
        
    }


    public void DeathEnemy()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star" || collision.gameObject.tag == "Player")
        {
            DeathEffectController.DeathEffect(gameObject.transform.position);
            Destroy(gameObject);
            TextController.AddScore();
        }
        if (collision.gameObject.tag == "Player")
        {
            player.Damege();
        }
    }
}
