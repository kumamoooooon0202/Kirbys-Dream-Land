using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, -10);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -10);
        }
        if (transform.position.x >= 52)
        {
            transform.position = new Vector3(52, 0, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "aaa")
        {
            Debug.Log("aaa");
        }
    }
}
