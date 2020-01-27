using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform farstBG;
    [SerializeField] private Transform lastBG;

    [SerializeField] private GameObject player;

    // カメラと壁のposisionの差
    private float posDif;

    void Start()
    {
        posDif = this.transform.position.x - farstBG.position.x; 
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, -10);

        if (transform.position.x < farstBG.position.x + posDif)
        {
            transform.position = new Vector3(farstBG.position.x + posDif, 0, -10);
        }
        if (transform.position.x >= lastBG.position.x - posDif)
        {
            transform.position = new Vector3(lastBG.position.x - posDif, 0, -10);
        }
    }
}
