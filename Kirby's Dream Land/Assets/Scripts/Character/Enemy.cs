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
}
