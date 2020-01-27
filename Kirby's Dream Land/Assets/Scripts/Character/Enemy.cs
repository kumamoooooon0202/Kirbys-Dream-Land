using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    void Start()
    {
        //HP = 1;
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
        }
    }
}
