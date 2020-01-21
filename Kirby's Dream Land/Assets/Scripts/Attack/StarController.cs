using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Transform transform;
    private GameObject player;
    void Start()
    {
        transform = GetComponent<Transform>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -5));
        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x + 0.1f, player.transform.position.y, 0);
    }
}
